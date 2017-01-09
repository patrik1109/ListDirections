using ListDirections.Models;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListDirections.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View(ContextProcess.Object.MainProceses.ToArray());
        }       

        public ActionResult StartProcess(int id)
        {
            MainProcess p = ContextProcess.Object.MainProceses.Find(id);
            if (p.CurrentStateName == ProcState.HaveToRun)
            {
                int new_session = p.Process_History.Count() == 0 ? 1 : p.Process_History.Max(h => h.SessionID) + 1;
                History history =  new History { SessionID = new_session, ProcessID = id, EventID = 0 };
                ContextProcess.Object.Historys.Add(history);
                ContextProcess.Object.SaveChanges();
                p.Refresh();
            }
            return View("Index", ContextProcess.Object.MainProceses.ToArray());
        }

        public ActionResult StartStep(int id)
        {
            PreRequisite step = ContextProcess.Object.PreRequisites.Find(id);
            MainProcess p = ContextProcess.Object.MainProceses.Find(step.ProcessID);
            if (p.CurrentStateName == ProcState.Running && p.CurrentStep.ID == id)
            {
                History history = new History { SessionID = p.CurrentResult.SessionID, ProcessID = p.ID, EventID = id };                               
                ContextProcess.Object.Historys.Add(history);
                ContextProcess.Object.SaveChanges();
                p.Refresh();
            }
            return View("Index", ContextProcess.Object.MainProceses.ToArray());
        }

        public ActionResult FinishStep(int id)
        {
            PreRequisite step = ContextProcess.Object.PreRequisites.Find(id);
            MainProcess p = ContextProcess.Object.MainProceses.Find(step.ProcessID);
            if (p.CurrentStateName == ProcState.Running && p.CurrentStep.ID == id)
            {
                History history = p.Current_State.FirstOrDefault(h => h.EventID == id);
                if (history != null)
                {
                    string path_to_file;
                    string err;
                    
                    history.Success = step.Check(out err,out path_to_file);
                  
                    if (history.Success.Value)
                    {
                        history.TimeFinish = DateTime.Now;
                        history.ErrorMessage = string.Empty;
                        
                    }
                    else
                    {
                        history.TimeFinish = null;
                        history.ErrorMessage = err;
                    }
                    ContextProcess.Object.SaveChanges();
                    p.Refresh();
                }
            }
            return View("Index", ContextProcess.Object.MainProceses.ToArray());
        }

        public ActionResult ExecuteScript(int id)
        {
            MainProcess p = ContextProcess.Object.MainProceses.Find(id);
            if (p.CurrentStateName == ProcState.Running && p.CurrentStep == null)
            {
                History history = p.Current_State.FirstOrDefault(h => h.EventID == 0);
                if (history != null)
                {
                    /*if (string.IsNullOrEmpty(p.FinalScript))
                    {
                        history.Success = false;
                        history.ErrorMessage = "Final script is empty.";
                    }
                    else
                    {
                        try
                        {
                            ProcessStartInfo pInfo = new ProcessStartInfo("cmd.exe");
                            pInfo.CreateNoWindow = true;
                            pInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            if (!string.IsNullOrEmpty(p.WorkingDir)) pInfo.WorkingDirectory = p.WorkingDir;
                            pInfo.RedirectStandardInput = true;
                            pInfo.UseShellExecute = false;
                            Process system_process = Process.Start(pInfo);
                            system_process.StandardInput.WriteLine(p.FinalScript);
                            system_process.StandardInput.Flush();
                            history.Success = true;
                        }
                        catch (Exception ex)
                        {
                            history.Success = false;
                            history.ErrorMessage = ex.GetBaseException().Message;
                        }
                    }*/

                    // К выполнению скрипта вернемся позже, пока просто закончим процесс с успехом.
                    history.Success = true;

                    history.TimeFinish = DateTime.Now;
                    ContextProcess.Object.SaveChanges();
                    p.Refresh();
                }
            }
            return View("Index", ContextProcess.Object.MainProceses.ToArray());
        }
    }
}