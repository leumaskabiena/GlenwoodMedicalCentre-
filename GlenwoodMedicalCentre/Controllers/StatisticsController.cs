using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class StatisticsController : Controller
    {
        StatisticsBusiness sb = new StatisticsBusiness();
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View("AgeChart");
        }

        public ActionResult DrugChart()
        {
            return View();
        }

        public ActionResult DashBoard()
        {
            return View();
        }

        [Authorize]
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult AgeChart()
        {
            return View();
        }

        public PartialViewResult AgeCht(int? number1, int? number2, int? number3)
        {
            return PartialView("_Age");
        }

        public JsonResult AgeGroup(int? number1, int? number2, int? number3)
        {
            return new JsonResult { Data = sb.AgeData(number1, number2, number3), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult DrugStatus()
        {
            return new JsonResult { Data = sb.DrugData(), JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }


        public JsonResult ProfitYearSelection()
        {
            return new JsonResult { Data = sb.ProfitYear(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult ProfitMonthSelection(int year)
        {
            return new JsonResult { Data = sb.ProfitMonth(year), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult ProfitDaysSelection(int year, string month)
        {
            return new JsonResult { Data = sb.ProfitDays(year, month), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
