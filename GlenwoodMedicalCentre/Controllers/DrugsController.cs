using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GlenwoodMed.BusinessLogic;
using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data;
using PagedList;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using GlenwoodMed.Model;


namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class DrugsController : Controller
    {
        DataContext db = new DataContext();
        DrugBusiness dbo = new DrugBusiness();
        //[AcceptVerbs(HttpVerbs.Post)]
        //public JsonResult AutoComplete(string term)
        //{
        //    //var result = new List<KeyValuePair<string, string>>();
        //    var result = (from auto in db.Drugs where auto.DrugName.ToLower().Contains(term.ToLower()) select new { auto.DrugName }).Distinct();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult searchdrug(string term)
        {
            var drugname = (from r in db.Drugs
                            where r.DrugName.ToLower().Contains(term.ToLower())
                            select new { r.DrugName }).Distinct();

           return Json(drugname, JsonRequestBehavior.AllowGet);
        }

        public JsonResult searchdrugprop(string term)
        {
            var drugname = (from r in db.Drug_Properties
                            where r.DrugCode.ToLower().Contains(term.ToLower())
                            select new { r.DrugCode, r.DrugName }).Distinct();

            return Json(drugname, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult SDrugs(int? page, int pageSize = 5, string drugpar = "")
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            //int pageSize = 5;
            int pageNumber = (page ?? 1);


            List<DrugModel> alldrugs = dbo.GetAll().OrderBy(x => x.DrugCode).ThenBy(x => x.DrugType).Where(x => x.DrugName.ToLower().Contains(drugpar.ToLower()) ||
                                                   drugpar == null).ToList();

            PagedList<DrugModel> model = new PagedList<DrugModel>(alldrugs, pageNumber, pageSize);
            //return View("MainIndex", model);
            return PartialView("_SDrug", model);
        }

        //
        [Authorize]
        public ActionResult Details(int? id)
        {
            var dbo = new DrugBusiness();
            return PartialView(dbo.DetailsMethod(id));
        }
        [Authorize]
        public ActionResult Create()
        {
            var dbo = new DrugBusiness();

            //return View();
            return PartialView();
        }


        [HttpPost]
        [Authorize]
        public ActionResult Create(DrugModel model, string DrugType)
        {
            try
            {
                var dbo = new DrugBusiness();

                if(dbo.nameexists(model.DrugCode, DrugType))
                {
                    ModelState.AddModelError("", "Drug already exists, you can only increase quantity & change price for drug");
                    return View(model);
                }

                dbo.CreateMethod(model, DrugType);
                foreach (DrugModel dg in dbo.GetAll())
                {
                    ViewBag.DrugName = dg.DrugName;
                }
                //TempData["msg"] = "Data has been successfully saved";
                return RedirectToAction("Index");

            }
            catch (DataException)
            {

                return View(model);
            }
        }
        [Authorize]
        public ActionResult Update(int id)
        {
            var dbo = new DrugBusiness();
            return PartialView(dbo.GetReviewMethod(id));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Update(int id, DrugModel model)
        {
            try
            {
                var dbo = new DrugBusiness();

                dbo.PostReviewMethod(model);
                TempData["msg"] = "Data has been successfully Updated";
                return RedirectToAction("Index");

            }
            catch
            {

                return View();
            }
        }
        //[Authorize]
        //public ActionResult Delete(int id)
        //{

        //    var dbo = new DrugBusiness();
        //    return PartialView(dbo.GetDeleteMethod(id));
        //}

        //[HttpPost]//, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id, DrugModel model)
        {
            try
            {
                var dbo = new DrugBusiness();
                dbo.PostDeleteMethod(id);
                TempData["msg"] = "Data has been Deleted";
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}