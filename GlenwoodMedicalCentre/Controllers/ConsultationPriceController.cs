using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlenwoodMed.BusinessLogic;
using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class ConsultationPriceController : Controller
    {
        // GET: ConsultationPrice
        private ConsultationPriceBusiness cons = new ConsultationPriceBusiness();
        public ActionResult Index()
        {
            return View(cons.GetAllPrice());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ConsultationPriceView cv)
        {
            cons.CreateMethod(cv);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
           return View(cons.GETeditMethod(id));

        }
        [HttpPost]
        public ActionResult Edit(int id,ConsultationPriceView cpv)
        {
            cons.PostEditMethod(cpv);
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            return View(cons.DetailsMethod(id));
        }
    }
}