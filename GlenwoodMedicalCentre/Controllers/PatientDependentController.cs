using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class PatientDependentController : Controller
    {
        DependentBusiness db = new DependentBusiness();
        PatientBusiness pb = new PatientBusiness();
        PatientRepository pr = new PatientRepository();

        // GET: PatientDependent
        [Authorize]
        public ActionResult Index(int patId)
        {
            var IntID = Convert.ToInt32(patId);

            var name = pb.GetPatients().ToList().Find(x => x.PatientId == IntID);

            ViewBag.PatientName = name.FullName.ToString().ToUpper();

            return View(db.GetAllDependents(patId));
        }

        // GET: PatientDependent/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            return PartialView(db.DetailsMethod(id));
        }

        // GET: PatientDependent/Create
        [Authorize]
        [HttpPost]
        public ActionResult CancelRegistration()
        {
            int patientid = Convert.ToInt32(System.Web.HttpContext.Current.Session["PatientId"]);
            int Id = Convert.ToInt32(System.Web.HttpContext.Current.Session["Cancel"]);
            var user = pb.GetPatients().Find(x => x.PatientId == Id);

            pr.Delete(user);

            return RedirectToAction("Index", "Patient");
        }

        // GET: PatientDependent/Create
        [Authorize]
        public ActionResult Create()
        {
            int patientid = Convert.ToInt32(System.Web.HttpContext.Current.Session["PatientId"]);
            System.Web.HttpContext.Current.Session["Cancel"] = patientid;
            var user = pb.GetPatients().Find(x => x.PatientId == patientid);

            var model = new DependentModel
            {
                patientName = user.Title + " " + user.FullName.ToUpper() + " " + user.Surname.ToUpper()
            };

            return View(model);
        }

        [Authorize]
        public ActionResult AddDependent(int? PatientId)
        {
            var user = pb.GetPatients().Find(x => x.PatientId == PatientId.Value);

            var model = new DependentModel
            {
                patientName = user.Title + " " + user.FullName.ToUpper() + " " + user.Surname.ToUpper()
            };

            return View(model);
        }

        // POST: PatientDependent/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(DependentModel _depmodel, string Id, string Gender, string Role, string Title)
        {
            try
            {
                int patientid = Convert.ToInt32(System.Web.HttpContext.Current.Session["PatientId"]);

                db.CreateMethod(_depmodel, patientid, Gender, Role, Title);
                TempData["Msg"] = "Data has been saved succeessfully";
                return RedirectToAction("Index", "PatientDependent", new { patId = patientid });
            }
            catch
            {
                return View();
            }
        }


        // GET: PatientDependent/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return PartialView(db.GETeditMethod(id));
        }

        // POST: PatientDependent/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, DependentModel _depmodel)
        {
            try
            {
                // TODO: Add update logic here
                db.PostEditMethod(_depmodel);
                TempData["Msg"] = "Data has been updated succeessfully";
                return RedirectToAction("Index", "PatientDependent", new { patId = db.GetDependentId(id).PatientId });
            }
            catch
            {
                return PartialView();
            }
        }

        // GET: PatientDependent/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return PartialView(db.GETdeleteMethod(id));
        }

        // POST: PatientDependent/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id, DependentModel _depmodel)
        {
            try
            {
                // TODO: Add delete logic here
                int thisId = id;
                db.PostDeleteMethod(id);
                TempData["Msg"] = "Data has been deleted succeessfully";
                return RedirectToAction("Index", "PatientDependent", new { patId = db.GetDependentId(id).PatientId });
            }
            catch
            {
                return PartialView();
            }
        }
    }
}
