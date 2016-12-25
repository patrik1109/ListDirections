using ListDirections.Models;
using System;
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
            ViewBag.Title = "Process List";
            return View(ContextProcess.Object.MainProceses.ToArray());
        }       

        public ActionResult StartProcess(int id)
        {
            MainProcess p = ContextProcess.Object.MainProceses.Find(id);
            if (p.CurrentStateName == ProcState.HaveToRun)
            {
                int new_session = p.Process_History.Count() == 0 ? 1 : p.Process_History.Max(h => h.SessionID) + 1;
                History history=  new History {
                    SessionID = new_session,ProcessID = id, EventID = 0, TimeStart = DateTime.Now, TimeFinish = null, Success = false };
                ContextProcess.Object.Historys.Add(history);
                ContextProcess.Object.SaveChanges();
                p.Refresh();
            }
            return View("Index", ContextProcess.Object.MainProceses.ToArray());
        }
    }
}