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

        public ActionResult ExceptionReport()
        {
            return View();
        }

        public ActionResult SummaryReport()
        {
            return View();
        }
    }
}