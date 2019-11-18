using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Report_Layout.Models;

namespace Report_Layout.Controllers
{
    public class ReportController : Controller
    {
        
        DBManager db = new DBManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetailReport()
        {
            var detail = db.GetDetailReport();
            return View(detail);
        }
        [HttpGet]
        public ActionResult ExceptionReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExceptionReport(FormCollection collection)
        {
            string val = collection["ExceptionValue"];
            Except type = (Except)Enum.Parse(typeof(Except), collection["ExceptionType"]);
            Inequality ineq = (Inequality)Enum.Parse(typeof(Inequality), collection["EqualityType"]);

            ViewBag.date = true;
            var execption = db.GetExceptionReport(type, ineq, val);
            return View("ExceptionReportList", execption);
        }

        public ActionResult ExceptionReportList()
        {
            return View();
        }
        public ActionResult SummaryReport()
        {
            var summary = db.GetSummaryReport();
            return View(summary);
        }
    }
}