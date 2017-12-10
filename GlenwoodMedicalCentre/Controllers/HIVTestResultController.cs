using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Data;
using PagedList;

namespace GlenwoodMedicalCentre.Controllers
{
    //copyright
    [RequireHttps]
    public class HIVTestResultController : Controller
    {
      
        HIVTestResultBusiness ee = new HIVTestResultBusiness();
        //
        // GET: /TestResult/
        public ActionResult Index(int? page, int Id, int pageSize = 5, string test = "")
        {
            //search by name
            List<HIVTestResultModel> myList = ee.GetAllTest().FindAll(x => x.PatientId == Id).ToList();
            var search = myList.OrderBy(x => x.Date).Where(x => x.PatientName.ToLower().Contains(test.ToLower())
                                                                             || test == null).ToList();
           // var search = from a in ee.GetAllTest() where a.PatientId == id orderby a.Date descending select a;

            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);

            List<HIVTestResultModel> pm = search;
            PagedList<HIVTestResultModel> model = new PagedList<HIVTestResultModel>(pm, pageNumber, pageSize);
            
            ViewBag.ee = ee.Count();
            TempData["msg"] = ee.CountNeg();

            return View("Index", pm.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /TestResult/Details/5
        public ActionResult Details(int id)
        {
            return PartialView(ee.Details(id));
        }

        //
        // GET: /TestResult/Create
        public ActionResult Create(int ? PatientId)
        {
            var ee = new HIVTestResultBusiness();
            var Pb = new PatientBusiness();
            if(PatientId.HasValue)
            {
                var Pname = Pb.GetPatients().Find(x => x.PatientId == PatientId.Value);
                var model = new HIVTestResultModel
                {
                    PatientName = Pname.FullName.ToUpper() + " " + Pname.Surname.ToUpper(),
                    PatientId = PatientId.Value
                };
                System.Web.HttpContext.Current.Session["himPatientId"] = PatientId;
                return View(model);
            }
            return View();
        }

    
        // POST: /TestResult/Create
        [HttpPost]
        public ActionResult Create(HIVTestResultModel test)
        {
            try
            {
                var ee = new HIVTestResultBusiness();
                int PatientId = Convert.ToInt32(System.Web.HttpContext.Current.Session["himPatientId"]);


                ee.Create(test, PatientId);
                return RedirectToAction("Index", new { Id = PatientId });
            }
            catch
            {
                return View(test);
            }
        }

        //
        // GET: /TestResult/Edit/5
        public ActionResult Edit(int id)
        {

            return View(ee.GetEdit(id));
        }

        //
        // POST: /TestResult/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HIVTestResultModel test)
        {
            try
            {
                // TODO: Add update logic here
                ee.PostEdit(test);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /TestResult/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ee.GetDelete(id));
        }

        //
        // POST: /TestResult/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, HIVTestResultModel Test)
        {
            try
            {
                // TODO: Add delete logic here
                var hmm = ee.GetAllTest().Find(x => x.TestId == id);
                ee.PostDelete(id);
                return RedirectToAction("Index", new { Id = hmm.PatientId });
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Update(int id)
        {
            return View(ee.GetEdit(id));
        }
        [HttpPost]
        public ActionResult Update(int id, HIVTestResultModel test)
        {

            var hmm = ee.GetAllTest().Find(x => x.TestId == id);
            ee.PostEdit(test);
            return RedirectToAction("Index", new { Id = hmm.PatientId }); // PartialView();
        }


        public ActionResult AddTestResult(int? page, string testpar = "")
        {
            var dbo = new PatientBusiness();

            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View("AddTestResult", dbo.GetAllPatients().Where(x => x.FullName.ToLower().Contains(testpar.ToLower()) ||
                                                                x.Surname.ToLower().Contains(testpar.ToLower()) ||
                                                                x.NationalId.ToLower().Contains(testpar.ToLower()) ||
                                                                testpar == null).ToPagedList(pageNumber, pageSize));
        }
    }
}
