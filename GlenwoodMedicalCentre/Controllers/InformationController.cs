using GlenwoodMed.BusinessLogic.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMedicalCentre.Models;
using GlenwoodMed.Data.Tables;
using RazorPDF;
//using System.Data.Entity.Core.Objects;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class InformationController : Controller
    {
        PatientBusiness pb = new PatientBusiness();
        InformationBusiness ib = new InformationBusiness();

        // GET: Information
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        #region Patient Information
        [Authorize]
        public PartialViewResult _AllPatients(int? page, int pageSize = 5)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);

            return PartialView("_PatientList", pb.GetAllPatients().ToPagedList(pageNumber, pageSize));
        }

        

        public PartialViewResult _specificPatients(int? page, int pageSize = 5)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);

            ViewBag.Count = 0;
            List<PatientModel> pm = new List<PatientModel>();
            return PartialView("_specificInfo", pm.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public PartialViewResult _specificPatients(int? searchit, string sinDate, string range1, string range2, string specify, int? page, int pageSize = 5)
        {
            int count = 0;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);

            if (specify == "Days" && searchit.HasValue)
            {
                List<PatientModel> pm = pb.GetAllPatients().FindAll(x => x.registeredDate > DateTime.Today.AddDays(-searchit.Value)).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificInfo", pm.ToPagedList(pageNumber, pageSize));
            }

            else if (specify == "Months" && searchit.HasValue)
            {
                List<PatientModel> pm = pb.GetAllPatients().FindAll(x => x.registeredDate > DateTime.Today.AddMonths(-searchit.Value)).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificInfo", pm.ToPagedList(pageNumber, pageSize));
            }

            else if (specify == "Years" && searchit.HasValue)
            {
                List<PatientModel> pm = pb.GetAllPatients().FindAll(x => x.registeredDate > DateTime.Today.AddYears(-searchit.Value)).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificInfo", pm.ToPagedList(pageNumber, pageSize));
            }

            else if (range1 != "" && range2 != "")
            {
                DateTime rg1 = Convert.ToDateTime(range1);
                DateTime rg2 = Convert.ToDateTime(range2);

                List<PatientModel> pm = pb.GetAllPatients().FindAll(x => x.registeredDate >= rg1 && x.registeredDate <= rg2).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificInfo", pm.ToPagedList(pageNumber, pageSize));
            }

            else if (sinDate != null)
            {
                DateTime sin = Convert.ToDateTime(sinDate);
                List<PatientModel> pm = pb.GetAllPatients().FindAll(x => DateTime.Equals(x.registeredDate, sin)).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificInfo", pm.ToPagedList(pageNumber, pageSize));
            }

            else if((searchit.Value == 0) || (!searchit.HasValue))
            {
                ViewBag.Count = 0;
                List<PatientModel> pm = new List<PatientModel>();
                return PartialView("_specificInfo", pm.ToPagedList(pageNumber, pageSize));
            }

            else
            {
                return PartialView("_specificInfo", pb.GetAllPatients().ToPagedList(pageNumber, pageSize));
            }
        }

        public PartialViewResult _7DaysPatients(int? page, int pageSize = 5)
        {
            int count = 0;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);
            DateTime date = DateTime.Now.Date;
            List<PatientModel> pm = pb.GetAllPatients().FindAll(x => x.registeredDate > DateTime.Today.AddDays(-7)).ToList();

            foreach (var p in pm)
            {
                count++;
            }

            ViewBag.Count = count;

            return PartialView("_7days", pm.ToPagedList(pageNumber, pageSize));
        }

        public PartialViewResult _1monthPatients(int? page, int pageSize = 5)
        {
            int count = 0;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);
            DateTime date = DateTime.Now.Date;
            List<PatientModel> pm = pb.GetAllPatients().FindAll(x => x.registeredDate > DateTime.Today.AddMonths(-1)).ToList();

            foreach (var p in pm)
            {
                count++;
            }

            ViewBag.Count = count;

            return PartialView("_1month", pm.ToPagedList(pageNumber, pageSize));
        }

        public PartialViewResult _1yearPatients(int? page, int pageSize = 5)
        {
            int count = 0;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);
            DateTime date = DateTime.Now.Date;
            List<PatientModel> pm = pb.GetAllPatients().FindAll(x => x.registeredDate > DateTime.Today.AddYears(-1)).ToList();

            foreach (var p in pm)
            {
                count++;
            }

            ViewBag.Count = count;

            return PartialView("_1year", pm.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region Medical Certificate Information
        public PartialViewResult _AllMedCertificates(int? page, int pageSize = 5)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);

            return PartialView("_MedList", ib.GetAllCertificates().ToPagedList(pageNumber, pageSize));
        }

        public PartialViewResult _specificMedical(int? page, int pageSize = 5)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);

            ViewBag.Count = 0;
            List<MedicalCertificateModel> pm = new List<MedicalCertificateModel>();
            return PartialView("_specificMed", pm.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public PartialViewResult _specificMedical(int? searchit, string sinDate, string range1, string range2, string specify, int? page, int pageSize = 5)
        {
            int count = 0;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);

            if (specify == "Days" && searchit.HasValue)
            {
                List<MedicalCertificateModel> pm = ib.GetAllCertificates().FindAll(x => x.Date > DateTime.Today.AddDays(-searchit.Value)).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificMed", pm.ToPagedList(pageNumber, pageSize));
            }

            else if (specify == "Months" && searchit.HasValue)
            {
                List<MedicalCertificateModel> pm = ib.GetAllCertificates().FindAll(x => x.Date > DateTime.Today.AddMonths(-searchit.Value)).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificMed", pm.ToPagedList(pageNumber, pageSize));
            }

            else if (specify == "Years" && searchit.HasValue)
            {
                List<MedicalCertificateModel> pm = ib.GetAllCertificates().FindAll(x => x.Date > DateTime.Today.AddYears(-searchit.Value)).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificMed", pm.ToPagedList(pageNumber, pageSize));
            }

            else if (range1 != "" && range2 != "")
            {
                DateTime rg1 = Convert.ToDateTime(range1);
                DateTime rg2 = Convert.ToDateTime(range2);

                List<MedicalCertificateModel> pm = ib.GetAllCertificates().FindAll(x => x.Date >= rg1 && x.Date <= rg2).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificMed", pm.ToPagedList(pageNumber, pageSize));
            }

            else if (sinDate != null)
            {
                DateTime sin = Convert.ToDateTime(sinDate);
                List<MedicalCertificateModel> pm = ib.GetAllCertificates().FindAll(x => DateTime.Equals(x.Date, sin)).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificMed", pm.ToPagedList(pageNumber, pageSize));
            }

            else if ((searchit.Value == 0) || (!searchit.HasValue))
            {
                ViewBag.Count = 0;
                List<MedicalCertificateModel> pm = new List<MedicalCertificateModel>();
                return PartialView("_specificMed", pm.ToPagedList(pageNumber, pageSize));
            }

            else
            {
                return PartialView("_specificMed", pb.GetAllPatients().ToPagedList(pageNumber, pageSize));
            }
        }

        public PartialViewResult _7DaysMedical(int? page, int pageSize = 5)
        {
            int count = 0;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);
            DateTime date = DateTime.Now.Date;
            List<MedicalCertificateModel> pm = ib.GetAllCertificates().FindAll(x => x.Date > DateTime.Today.AddDays(-7)).ToList();

            foreach (var p in pm)
            {
                count++;
            }

            ViewBag.Count = count;

            return PartialView("_7daysMed", pm.ToPagedList(pageNumber, pageSize));
        }

        public PartialViewResult _1monthMedical(int? page, int pageSize = 5)
        {
            int count = 0;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);
            DateTime date = DateTime.Now.Date;

            List<MedicalCertificateModel> pm = ib.GetAllCertificates().FindAll(x => x.Date > DateTime.Today.AddMonths(-1)).ToList();

            foreach (var p in pm)
            {
                count++;
            }

            ViewBag.Count = count;

            return PartialView("_1monthMed", pm.ToPagedList(pageNumber, pageSize));
        }

        public PartialViewResult _1yearMedical(int? page, int pageSize = 5)
        {
            int count = 0;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);
            DateTime date = DateTime.Now.Date;
            List<MedicalCertificateModel> pm = ib.GetAllCertificates().FindAll(x => x.Date > DateTime.Today.AddYears(-1)).ToList();

            foreach (var p in pm)
            {
                count++;
            }

            ViewBag.Count = count;

            return PartialView("_1yearMed", pm.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region Consultation Information
        public PartialViewResult _AllConsultations(int? page, int pageSize = 5)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);

            return PartialView("_ConsultationList", ib.GetAllConsultations().ToPagedList(pageNumber, pageSize));
        }

        public PartialViewResult _specificCon(int? page, int pageSize = 5)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);

            ViewBag.Count = 0;
            List<ConsultationView> pm = new List<ConsultationView>();
            return PartialView("_specificConsult", pm.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public PartialViewResult _specificCon(int? searchit, string sinDate, string range1, string range2, string specify, int? page, int pageSize = 5)
        {
            int count = 0;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);

            if (specify == "Days" && searchit.HasValue)
            {
                List<ConsultationView> pm = ib.GetAllConsultations().FindAll(x => x.ConsultDate > DateTime.Today.AddDays(-searchit.Value)).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificConsult", pm.ToPagedList(pageNumber, pageSize));
            }

            else if (specify == "Months" && searchit.HasValue)
            {
                List<ConsultationView> pm = ib.GetAllConsultations().FindAll(x => x.ConsultDate > DateTime.Today.AddMonths(-searchit.Value)).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificConsult", pm.ToPagedList(pageNumber, pageSize));
            }

            else if (specify == "Years" && searchit.HasValue)
            {
                List<ConsultationView> pm = ib.GetAllConsultations().FindAll(x => x.ConsultDate > DateTime.Today.AddYears(-searchit.Value)).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificConsult", pm.ToPagedList(pageNumber, pageSize));
            }

            else if (range1 != "" && range2 != "")
            {
                DateTime rg1 = Convert.ToDateTime(range1);
                DateTime rg2 = Convert.ToDateTime(range2);

                List<ConsultationView> pm = ib.GetAllConsultations().FindAll(x => x.ConsultDate >= rg1 && x.ConsultDate <= rg2).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificConsult", pm.ToPagedList(pageNumber, pageSize));
            }

            else if (sinDate != null)
            {
                DateTime sin = Convert.ToDateTime(sinDate);
                List<ConsultationView> pm = ib.GetAllConsultations().FindAll(x => DateTime.Equals(x.ConsultDate, sin)).ToList();
                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return PartialView("_specificConsult", pm.ToPagedList(pageNumber, pageSize));
            }

            else if ((searchit.Value == 0) || (!searchit.HasValue))
            {
                ViewBag.Count = 0;
                List<ConsultationView> pm = new List<ConsultationView>();
                return PartialView("_specificConsult", pm.ToPagedList(pageNumber, pageSize));
            }

            else
            {
                return PartialView("_specificConsult", ib.GetAllConsultations().ToPagedList(pageNumber, pageSize));
            }
        }

        public PartialViewResult _7DaysConsult(int? page, int pageSize = 5)
        {
            int count = 0;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);
            DateTime date = DateTime.Now.Date;
            List<ConsultationView> pm = ib.GetAllConsultations().FindAll(x => x.ConsultDate > DateTime.Today.AddDays(-7)).ToList();

            foreach (var p in pm)
            {
                count++;
            }

            ViewBag.Count = count;

            return PartialView("_7daysConsult", pm.ToPagedList(pageNumber, pageSize));
        }

        public PartialViewResult _1monthConsult(int? page, int pageSize = 5)
        {
            int count = 0;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);
            DateTime date = DateTime.Now.Date;

            List<ConsultationView> pm = ib.GetAllConsultations().FindAll(x => x.ConsultDate > DateTime.Today.AddMonths(-1)).ToList();

            foreach (var p in pm)
            {
                count++;
            }

            ViewBag.Count = count;

            return PartialView("_1monthConsult", pm.ToPagedList(pageNumber, pageSize));
        }

        public PartialViewResult _1yearConsult(int? page, int pageSize = 5)
        {
            int count = 0;
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);
            DateTime date = DateTime.Now.Date;
            List<ConsultationView> pm = ib.GetAllConsultations().FindAll(x => x.ConsultDate > DateTime.Today.AddYears(-1)).ToList();

            foreach (var p in pm)
            {
                count++;
            }

            ViewBag.Count = count;

            return PartialView("_1yearMed", pm.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region Print Actions
        [Authorize]
        public ActionResult PrintAllPatients(string id)
        {
            int count = 0;
            PatientBusiness pb = new PatientBusiness();
            // With no Model and default view name.  Pdf is always the default view name
            //return new PdfResult();
            if(id == "7days")
            {
                List<PatientModel> pm = pb.GetAllPatients().FindAll(x => x.registeredDate > DateTime.Today.AddDays(-7)).ToList();

                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return new PdfResult(pm, "PrintAllPatients");
            }

            else if (id == "1month")
            {
                List<PatientModel> pm = pb.GetAllPatients().FindAll(x => x.registeredDate > DateTime.Today.AddMonths(-1)).ToList();

                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return new PdfResult(pm, "PrintAllPatients");
            }

            else if (id == "1year")
            {
                List<PatientModel> pm = pb.GetAllPatients().FindAll(x => x.registeredDate > DateTime.Today.AddYears(-1)).ToList();

                foreach (var p in pm)
                {
                    count++;
                }

                ViewBag.Count = count;
                return new PdfResult(pm, "PrintAllPatients");
            }

            else
            {
                ViewBag.Count = 0;
                return new PdfResult(pb.GetAllPatients(), "PrintAllPatients");
            }     
        }

        [Authorize]
        public ActionResult PrintAllCertificates()
        {
            MedCertificateBusiness mb = new MedCertificateBusiness();
            // With no Model and default view name.  Pdf is always the default view name
            //return new PdfResult();
            return new PdfResult(mb.GetallMedCert(), "PrintAllCertificates");
        }

        [Authorize]
        public ActionResult PrintAllConsultations()
        {
            ConsultationBusiness cb = new ConsultationBusiness();
            // With no Model and default view name.  Pdf is always the default view name
            //return new PdfResult();
            return new PdfResult(ib.GetAllConsultations(), "PrintAllConsultations");
        }

        [Authorize]
        public ActionResult FramePrint(string ConsultId)
        {
            ViewBag.ConsultId = ConsultId;
            return View();
        }
        #endregion
    }
}