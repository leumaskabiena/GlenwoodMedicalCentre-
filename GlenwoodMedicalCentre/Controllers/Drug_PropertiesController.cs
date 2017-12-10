using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMedicalCentre.Controllers
{
    public class Drug_PropertiesController : Controller
    {
        DrugpropBusiness dp = new DrugpropBusiness();

        // GET: Drug_Properties
        public ActionResult Index()
        {
            return View(dp.GetAllDrugprop());
        }

        // GET: Drug_Properties/Details/5
        public ActionResult Details(string id)
        {
            return View(dp.DetailsMethod(id));
        }

        // GET: Drug_Properties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drug_Properties/Create
        [HttpPost]
        public ActionResult Create(Drug_PropertiesModel model)
        {
            try
            {
                // TODO: Add insert logic here
                dp.CreateMethod(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Drug_Properties/Edit/5
        public ActionResult Edit(string id)
        {
            return View(dp.GETeditMethod(id));
        }

        // POST: Drug_Properties/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Drug_PropertiesModel model)
        {
            try
            {
                // TODO: Add update logic here
                dp.PostEditMethod(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Drug_Properties/Delete/5
        public ActionResult Delete(string id)
        {
            return View(dp.GETdeleteMethod(id));
        }

        // POST: Drug_Properties/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                dp.PostDeleteMethod(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
