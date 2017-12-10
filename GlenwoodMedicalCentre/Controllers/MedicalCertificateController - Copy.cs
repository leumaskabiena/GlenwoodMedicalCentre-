using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMedicalCentre.Models;
using RazorPDF;
using System;
using PagedList.Mvc;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlenwoodMedicalCentre.Controllers
{
    public class MedicalCertificateController : Controller
    {  
        MedCertificateBusiness ee = new MedCertificateBusiness();
        PatientBusiness pb = new PatientBusiness();
        [Authorize(Roles="Doctor, Receptionist")]
        // GET: MedicalCertificate
        public ActionResult PrintCertificate(int PatientId)
        {
            PatientConsultationDetails med = new PatientConsultationDetails();

            med.MedCert = ee.GetAllCertificates().Find(x => x.PatientId == PatientId);
            return new PdfResult(med, "PrintCertificate");
        }
        //public ActionResult PrintMedCertificate(int PatientId)
        //{
            
        //    var med = new MedicalCertificate();
        //    return View();

        //}

        [Authorize(Roles = "Doctor, Receptionist")]
        public ActionResult CreateMedCertificate(int? PatientId)
        {
            var ee = new MedCertificateBusiness();
            var Pb = new PatientBusiness();
            if(PatientId.HasValue)
            {
                var Pname = Pb.GetPatients().Find(x => x.PatientId == PatientId.Value);
                var model = new MedicalCertificateModel
                {
                   PatintName = Pname.FullName + " " + Pname.Surname,
                    PatientId = PatientId.Value,
                   FileName = Pname.FileName,
                   FileType = Pname.FileType,
                   resultFile = Pname.File

                };
                System.Web.HttpContext.Current.Session["PId"] = PatientId;
                return View(model);
            }
                return View();
        }
      /*  public ActionResult Create(HIVTestResultModel test)
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
        }*/
        [Authorize(Roles = "Doctor, Receptionist")]
        [HttpPost]
        public ActionResult CreateMedCertificate(MedicalCertificateModel med)
        {
           
            try
            {
                // TODO: Add insert logic here
                var ee = new MedCertificateBusiness();
                int PatientId = Convert.ToInt32(System.Web.HttpContext.Current.Session["PId"]);
                ee.create(med,PatientId);
                return RedirectToAction("Index", new { PatientId = PatientId });
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Doctor, Receptionist")]
        public ActionResult Index(string sortOrder, string currentFilter, int PatientId)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var mode = new ExtraMedModel();
            mode.med = ee.GetallMedCert(PatientId);
            mode.medId = PatientId;

            //var name = ee.GetMedbyId(PatientId);
            string name = "";
            name = pb.GetPatient(PatientId).FullName + " " + pb.GetPatient(PatientId).Surname;
            ViewBag.Name = name;

            switch (sortOrder)
            {
                case "name_desc":
                    mode.med = ee.GetallMedCert(PatientId).OrderByDescending(x => x.PatintName).ToList();
                    break;
                case "Date":
                    mode.med = ee.GetallMedCert(PatientId).OrderBy(x => x.Date).ToList();
                    break;
                case "date_desc":
                    mode.med = ee.GetallMedCert(PatientId).OrderByDescending(x => x.Date).ToList();
                    break;
                default:  // Name ascending 
                    mode.med = ee.GetallMedCert(PatientId).OrderByDescending(x => x.PatintName).ToList();
                    break;
            }

            return View(mode);
        }
    }
}