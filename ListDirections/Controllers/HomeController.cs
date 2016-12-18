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
            ViewBag.Title = "Process List";
            return View(db.MainProceses.ToArray());
        }
        public Shedule[] Process_Shedule (int ID)
        {
            Shedule[] result = db.Sheduls.Where(s => s.ProcessID == ID).ToArray();
            return result;
        }
       
    }
}