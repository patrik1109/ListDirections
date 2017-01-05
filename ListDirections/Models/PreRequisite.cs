using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;
using System.Security;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace ListDirections.Models
{
    public class PreRequisite
    {
        public int ID { get; set; }

        [Index]
        public int ProcessID { get; set; }
        
        [MaxLength(50)]
        public string Name { get; set; }

        public int StepOrder { get; set; }
        
        public bool Check(out string err_message) 
        {
            err_message = string.Empty;
            bool result = true;
            string[] arg = Arguments.Split(';');

            if (Name.Equals("Copy file") && StepOrder != 3)
            {
                result = PermissionUserRead(arg[0]);
                if (!result)
                {
                    err_message = "Access dinited to path " + arg[0];
                }
            }
            else
            {
                try
                {
                    System.IO.File.Copy(arg[0], arg[1], true);
                }
                catch (Exception ex)
                {
                    err_message = ex.Message;
                    result = false;
                }
            }
            return result; 
        }
        public string Arguments { get; set; }
        public string Instruction { get; set; }

        public static bool PermissionUserWrite(string path)
        {
            bool result = false;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                DirectorySecurity sec = Directory.GetAccessControl(path, AccessControlSections.Access);
                AuthorizationRuleCollection dacls = sec.GetAccessRules(true, true, typeof(SecurityIdentifier));

                foreach (FileSystemAccessRule dacl in dacls)
                {
                    if ((dacl.FileSystemRights & FileSystemRights.Write) == FileSystemRights.Write)
                        result = true;
                }
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }
        public static bool PermissionUserRead(string path)
        {
            bool result = false;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                DirectorySecurity sec = Directory.GetAccessControl(path, AccessControlSections.Access);
                AuthorizationRuleCollection dacls = sec.GetAccessRules(true, true, typeof(SecurityIdentifier));

                foreach (FileSystemAccessRule dacl in dacls)
                {
                    if ((dacl.FileSystemRights & FileSystemRights.Read) == FileSystemRights.Read)
                        result = true;
                }
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }
    }
}