using System;
using System.Collections.Generic;
using GlenwoodMed.Model;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlenwoodMed.Data;
using GlenwoodMed.BusinessLogic;
//using GlenwoodMed.Model;
using System.Data.Entity;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        DataContext ee = new DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

}




