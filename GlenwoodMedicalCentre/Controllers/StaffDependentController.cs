//using GlenwoodMed.BusinessLogic;
//using GlenwoodMed.BusinessLogic.Business;
//using GlenwoodMed.Data;
//using GlenwoodMed.Model.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace GlenwoodMedicalCentre.Controllers
//{
//    public class StaffDependentController : Controller
//    {
//        DependentBusiness db = new DependentBusiness();
//        RegisterBusiness rg = new RegisterBusiness();

//        // GET: StaffDependent
//        //[Authorize]
//        public ActionResult Index(string patId)
//        {
//            var name = rg.GetUsers().Find(x => x.Id == patId);

//            ViewBag.PatientName = name.Title + " " + name.FullName.ToString().ToUpper() + " " + name.Surname.ToString().ToUpper();

//            return View(db.GetAllStaffDependents(patId));
//        }

//        // GET: StaffDependent/Details/5
//        //[Authorize]
//        public ActionResult Details(int? id)
//        {
//            return PartialView(db.DetailsMethod(id));
//        }

//        // GET: StaffDependent/Create
//        //[Authorize]
//        public ActionResult Create()
//        {
//            string patientid = System.Web.HttpContext.Current.Session["PatientId"].ToString();
//            var user = rg.GetUsers().Find(x => x.Id == patientid);

//            var model = new DependentModel
//            {
//                patientName = user.Title + " " + user.FullName.ToUpper() + " " + user.Surname.ToUpper()
//            };

//            return View(model);
//        }

//        // POST: StaffDependent/Create
//        [HttpPost]
//        //[Authorize]
//        public ActionResult Create(DependentModel _depmodel, string Gender, string Role, string Title)
//        {
//            try
//            {
//                string patientid = System.Web.HttpContext.Current.Session["PatientId"].ToString();

//                db.CreateMethod(_depmodel, patientid, Gender, Role, Title);
//                TempData["Msg"] = "Data has been saved succeessfully";
//                return RedirectToAction("Index", "StaffDependent", new { patId = patientid });
//            }
//            catch (Exception ex)
//            {
//                ModelState.AddModelError("Error", ex.Message);
//                return View(_depmodel);
//            }
//        }


//        // GET: StaffDependent/Edit/5
//        //[Authorize]
//        public ActionResult Edit(int id)
//        {
//            return PartialView(db.GETeditMethod(id));
//        }

//        // POST: StaffDependent/Edit/5
//        [HttpPost]
//        //[Authorize]
//        public ActionResult Edit(int id, DependentModel _depmodel, string Gender)
//        {
//            try
//            {
//                // TODO: Add update logic here
//                db.PostEditMethod(_depmodel);
//                TempData["Msg"] = "Data has been updated succeessfully";
//                return RedirectToAction("Index", "StaffDependent", new { patId = db.GetDependentId(id).PatientId });
//            }
//            catch
//            {
//                return PartialView();
//            }
//        }

//        // GET: StaffDependent/Delete/5
//        //[Authorize]
//        public ActionResult Delete(int id)
//        {
//            return PartialView(db.GETdeleteMethod(id));
//        }

//        // POST: StaffDependent/Delete/5
//        [HttpPost]
//        //[Authorize]
//        public ActionResult Delete(int id, DependentModel _depmodel)
//        {
//            try
//            {
//                // TODO: Add delete logic here
//                db.PostDeleteMethod(id);
//                TempData["Msg"] = "Data has been deleted succeessfully";
//                return RedirectToAction("Index", "StaffDependent", new { patId = db.GetDependentId(id).PatientId });
//            }
//            catch
//            {
//                return PartialView();
//            }
//        }     
//    }
//}
