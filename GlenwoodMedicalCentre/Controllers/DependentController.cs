using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.IRepository;
using GlenwoodMed.Service.RepositoryClass;
using GlenwoodMedicalCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class DependentController : Controller
    {
        DependentBusiness db = new DependentBusiness();
        PatientBusiness pb = new PatientBusiness();
        ConsultationDetails cd = new ConsultationDetails();
        // GET: Dependent
        [Authorize]
        public ActionResult Index(int patId)
        {
            var IntID = Convert.ToInt32(patId);

            var name = pb.GetPatients().ToList().Find(x => x.PatientId == IntID);

            ViewBag.PatientName = name.FullName.ToString().ToUpper();

            cd._DepModel = db.GetAllDependents(patId);
            cd._Dep = IntID;
            return View(cd);
        }

        // GET: Dependent/Details/5
         [Authorize]
        public ActionResult Details(int ? id)
        {
            return PartialView(db.DetailsMethod(id));
        }

        // GET: Dependent/Create
         [Authorize]
        public ActionResult Create(int? PatientId)
        {
             if(PatientId.HasValue)
             {
                 var name = pb.GetPatients().Find(x => x.PatientId == PatientId.Value);

                 var model = new DependentModel
                 {
                     patientName = name.FullName.ToUpper() + " " + name.Surname.ToUpper(),
                     DDLName = db.DDPatient()
                 };

                 System.Web.HttpContext.Current.Session["_Patient"] = PatientId;
                 return View(model);
             }

            //var model = new DependentModel
            //{
            //    patientName = name.
            //    DDLName = db.DDPatient()
            //};
             
            return View();
        }

        // POST: Dependent/AddDependent
        [HttpPost]
        [Authorize]
        public ActionResult Create(DependentModel _depmodel, int PatientId, string Gender, string Role, string Title)
        {
            try
            {
                PatientId = Convert.ToInt32(System.Web.HttpContext.Current.Session["_Patient"]);
                db.AdditionalCreateMethod(_depmodel, PatientId, Gender, Role, Title);
                TempData["Msg"] = "Data has been saved succeessfully";
                return RedirectToAction("Index", "Dependent", new { patId = PatientId });
            }
            catch
            {
                return View();
            }
        }

        
        // GET: Dependent/Edit/5
         [Authorize]
        public ActionResult Edit(int id)
        {
            return PartialView(db.GETeditMethod(id));
        }

        // GET: Dependent/Editfromprofile/5
         [Authorize]
        public ActionResult Editfromprofile(int id)
        {

            return PartialView(db.GETeditMethod(id));
        }

        // POST: Dependent/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, DependentModel _depmodel)
        {
            try
            {
                // TODO: Add update logic here
                db.PostEditMethod(_depmodel);
                TempData["Msg"] = "Data has been updated succeessfully";
                return RedirectToAction("Index", "Dependent", new { patId = db.GetDependentId(id).PatientId});
            }
            catch
            {
                return PartialView();
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Editfromprofile(int id, DependentModel _depmodel)
        {
            try
            {
                int PatientId = Convert.ToInt32(System.Web.HttpContext.Current.Session["DpId"]);

                // TODO: Add update logic here
                db.PostEditMethod(_depmodel);
                TempData["Msg"] = "Data has been updated succeessfully";
                return RedirectToAction("ViewPatient", "Patient", new { PatientId = PatientId });
            }
            catch
            {
                return PartialView();
            }
        }

        // GET: Dependent/Delete/5
         [Authorize]
        public ActionResult Delete(int id)
        {
            return PartialView(db.GETdeleteMethod(id));
        }

        // POST: Dependent/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id, DependentModel _depmodel)
        {
            try
            {
                // TODO: Add delete logic here
                int thisid = id;
                db.PostDeleteMethod(id);
                TempData["Msg"] = "Data has been deleted succeessfully";
                return RedirectToAction("Index", "Dependent", new { patId = db.GetDependentId(thisid).PatientId });
            }
            catch
            {
                return PartialView();
            }
        }
    }
}
