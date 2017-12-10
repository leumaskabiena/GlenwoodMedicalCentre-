using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMedicalCentre.Models;
using PagedList;
using RazorPDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class MedicalCertificateController : Controller
    {
        
        MedCertificateBusiness ee = new MedCertificateBusiness();
       
        // GET: MedicalCertificate

        public ActionResult MedView(int MedcertificateId)
        {
            ViewBag.Id = MedcertificateId;
            return View();
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult PrintCertificate(int MedcertificateId)
        {
            PatientConsultationDetails med = new PatientConsultationDetails();

            med.MedCert = ee.GetallMedCert().Find(x => x.MedcertificateId == MedcertificateId);
            return new PdfResult(med, "PrintCertificate");
        }
        //public ActionResult PrintMedCertificate(int PatientId)
        //{
            
        //    var med = new MedicalCertificate();
        //    return View();

        //}
       [Authorize(Roles = "Doctor")]
        public ActionResult CreateMedCertificate(int? PatientId12)
        {
            var ee = new MedCertificateBusiness();
            var Pb = new PatientBusiness();
          int  PatientId = Convert.ToInt32(Session["newpatientid"]);
           
            if (PatientId!=0)
            {
                var Pname = Pb.GetPatients().Find(x => x.PatientId == PatientId);
                var model = new MedicalCertificateModel
                {
                   PatintName = Pname.FullName.ToUpper() + " " + Pname.Surname.ToUpper(),
                    PatientId = PatientId,
                    FileName = Pname.FileName,
                    FileType = Pname.FileType,
                    resultFile = Pname.File

                };
                System.Web.HttpContext.Current.Session["PId"] = PatientId;
                return View(model);
            }
                return View();
        }
      
        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public ActionResult CreateMedCertificate(MedicalCertificateModel med)
        {
           
            try
            {
                // TODO: Add insert logic here
                var ee = new MedCertificateBusiness();
               int  PatientId = Convert.ToInt32(Session["newpatientid"]);
                //int PatientId = Convert.ToInt32(System.Web.HttpContext.Current.Session["PId"]);
                ee.create(med,PatientId);
                return RedirectToAction("Index", new { PatientId= PatientId });
            }
            catch
            {
                return View();
            }
        }
        
        [Authorize(Roles="Doctor")]
        public ActionResult Index(int? page, int PatientId, int pageSize = 5, string test = "")
        {
            Session["newpatientid"] = PatientId;
            List<MedicalCertificateModel> myList = ee.GetallMedCert().FindAll(x => x.PatientId == PatientId).ToList();
            var search = myList.OrderBy(x => x.Date).Where(x => x.PatintName.ToLower().Contains(test.ToLower())
                                                                         || test == null).ToList();

            var Pb = new PatientBusiness();
            var Pname = Pb.GetPatients().Find(x => x.PatientId == PatientId);

            string name = Pname.FullName + " " + Pname.Surname;

            ViewBag.Name = name;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);

            List<MedicalCertificateModel> mdcert = search;
            PagedList<MedicalCertificateModel> model = new PagedList<MedicalCertificateModel>(mdcert, pageNumber, pageSize);
            return View("Index", mdcert.ToPagedList(pageNumber, pageSize));   //(ee.GetallMedCert());
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult modifycontents(int id)
        {
            return View(ee.GetEdit(id));
        }
        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public ActionResult modifycontents(int id, MedicalCertificateModel med, int? nothing)
        {
            try
            {
                //int PatientId = Convert.ToInt32(Session["newpatientid"]);
                // var hmm = ee.GetallMedCert().Find(x => x.MedcertificateId == id);
                ee.PostEdit(med);
                return RedirectToAction("Index", new { PatientId = med.PatientId });
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult DeleteCertificate(int id,MedicalCertificateModel med)
        {
            TempData["data"] = med;
            return View(ee.GetDelete(id, med));
        }
        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public ActionResult DeleteCertificate(int id, MedicalCertificateModel med,int? da)
        {
            try
            {
                med = (MedicalCertificateModel)TempData["data"];
                // TODO: Add delete logic here
               // var medCert = ee.GetallMedCert().Find(x => x.MedcertificateId== id);
                ee.PostDelete(id);
                return RedirectToAction("Index", new { PatientId = med.PatientId });
            }
            catch
            {
                return View();
            }
        }

    }
}