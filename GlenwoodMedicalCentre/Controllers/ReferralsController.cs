using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data;
using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlenwoodMedicalCentre.Models;
using RazorPDF;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class ReferralsController : Controller
    {
        readonly ReferalBus rb = new ReferalBus();
        PatientBusiness pb = new PatientBusiness();

        public ActionResult Index()
        {
            return View(rb.GetAll());
        }

        public ActionResult Create(string ConsultId)
        {
            var pr = new PatientBusiness();
            var cb = new ConsultationBusiness();
            var rl = new ReferalBus();
            if (ConsultId != null)
            {
                var rlp = cb.GetConsultations().Find(x => x.ConsultId == ConsultId);
                var model = new ReferralModel
                {
                    Patient_name = rlp.patientfullname,
                    PatientId = rlp.PatientId,
                    Patient_age = pr.GetPatient(rlp.PatientId).Age,
                    Patient_number = pr.GetPatient(rlp.PatientId).Telephone,
                    diagnotics = rlp.Notes + "  " + rlp.Description
                };
                
                return View(model);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReferralModel model)
        {
            try
            {
                var rfm = new ReferalBus();
                rfm.CreateMethod(model);

                return new PdfResult(model, "PrintReferal");
                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PrintReferal(int PatientId)
        {
            PatientConsultationDetails pc = new PatientConsultationDetails();
            pc.Referrals = rb.GetAll().Find(x => x.PatientId == PatientId);
            return new PdfResult(pc, "PrintReferal");
        }
    }
}
