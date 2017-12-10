using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMedicalCentre.Models;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class PharmasistController : Controller
    {
        #region Objects
        ConsultationBusiness db = new ConsultationBusiness();
        private PrescriptionDrugs pres = new PrescriptionDrugs();
        private ConsultationDrugsBusiness bis = new ConsultationDrugsBusiness();
        #endregion
        // GET: Pharmasist
        #region Get collected drugs

        public ActionResult CollectedDrugs()
        {
            pres._CollectionViews = db.GetCollectedDrugs();
            pres._ConsultationDrugs = bis.ConsultationDrugs().ToList();
            return View(pres);
        }
        #endregion

        #region Details of  Consultation to Partial View
        public ActionResult PhaResultDetails(int id)
        {

            return PartialView(db.GetDetailsMethod(id));
        }
        #endregion

        #region Update the drug if it has been collected
        public ActionResult PostPharmar(int id)
        {
            db.UpdateCollectionDrug(id);
            TempData["msg"] = "Drug Collected";
            return RedirectToAction("PendingDrugs");
        }
        #endregion

        #region Get Drugs that are yet to be collected
        public ActionResult PendingDrugs()
        {

            return View(db.GetPendingDrugs());
        }
        #endregion

        #region Get all Prescriptions
        public ActionResult AllDrugs()
        {
            return View(db.AllConsultationDrugs());
        }
        #endregion
    }
}