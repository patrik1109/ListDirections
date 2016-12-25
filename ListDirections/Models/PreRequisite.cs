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
        
        public bool Check() { return true; }

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