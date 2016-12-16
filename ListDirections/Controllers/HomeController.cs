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
        ContextProcess db = new ContextProcess();
        public ActionResult Index()
        {
                       
            IEnumerable<MainProcess> proceses = db.MainProceses;
            MainProcess proc1 = db.MainProceses.Where(s => s.ID == 1).SingleOrDefault();
            History history = proc1.Process_History;

            //Shedule[] sheduls = Process_Shedule(1);           
            Shedule[] shedule = proc1.Process_Shedule;

            ViewBag.Proceses = proceses;
            return View();
        }
        public Shedule[] Process_Shedule (int ID)
        {
            Shedule[] result = db.Sheduls.Where(s => s.ProcessID == ID).ToArray();
            return result;
        }
       
    }
}