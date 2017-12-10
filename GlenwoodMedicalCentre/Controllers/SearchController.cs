using GlenwoodMed.BusinessLogic;
using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data;
using GlenwoodMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class SearchController : Controller
    {
        PatientBusiness pb = new PatientBusiness();
        DrugBusiness db = new DrugBusiness();
        RegisterBusiness rb = new RegisterBusiness();
        ConsultationBusiness cb = new ConsultationBusiness();
        //
        // GET: /Search/
        [Authorize]
        public ActionResult GeneralSearch()
        {
            return View();
        }


        #region
        //[Authorize]
        public PartialViewResult SPatient(int? page, int pageSize = 10, string patientpar = "")
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            //int pageSize = 5;
            int pageNumber = (page ?? 1);

            var patients = pb.GetAllPatients().ToList();
            List<PatientModel> mode =  pb.GetAllPatients().Where(x => x.FullName.ToLower().Contains(patientpar.ToLower()) ||
                                                    x.Surname.ToLower().Contains(patientpar.ToLower()) ||
                                                    x.Telephone.ToLower().Contains(patientpar.ToLower()) ||
                                                    x.NationalId.ToLower().Contains(patientpar.ToLower()) ||
                                                    x.Sex.ToLower().Contains(patientpar.ToLower()) ||
                                                    patientpar == null).ToList();

            PagedList<PatientModel> model = new PagedList<PatientModel>(mode, pageNumber, pageSize);
            //return View("_SearchPatient", bp.ToPagedList(pageNumber, pageSize));
            return PartialView("_SearchPatient", model);
        }
        #endregion

        public PartialViewResult SearchPatient(string patientpar = "")
        {
            var patients = pb.GetAllPatients().ToList();

            return PartialView(pb.GetAllPatients().Where(x => x.FullName.ToLower().Contains(patientpar.ToLower()) ||
                                                    x.Surname.ToLower().Contains(patientpar.ToLower()) ||
                                                    x.Telephone.ToLower().Contains(patientpar.ToLower()) ||
                                                    x.NationalId.ToLower().Contains(patientpar.ToLower()) ||
                                                    x.Sex.ToLower().Contains(patientpar.ToLower()) ||
                                                    patientpar == null).ToList());

        }

        #region
        //public JsonResult SPatient(string term = "")
        //{
        //    //var patients = pb.GetAllPatients().ToList();

        //    List<string> patients;

        //    patients = pb.GetAllPatients().Where(x => x.FullName.ToLower().StartsWith(term.ToLower())).Select(y => y.FullName).ToList();
        //    patients = pb.GetAllPatients().Where(x => x.Surname.ToLower().Contains(term.ToLower())).Select(y => y.Surname).ToList();
        //    patients = pb.GetAllPatients().Where(x =>x.Telephone.ToLower().Contains(term.ToLower())).Select(y => y.Telephone).ToList();
        //    patients = pb.GetAllPatients().Where(x =>x.NationalId.ToLower().Contains(term.ToLower())).Select(y => y.NationalId).ToList();
        //    patients = pb.GetAllPatients().Where(x =>x.Sex.ToLower().Contains(term.ToLower())).Select(y => y.Sex).ToList();
        //    patients = pb.GetAllPatients().Where(x =>x.MedicalAidName.ToLower().Contains(term.ToLower())).Select(y => y.MedicalAidName).ToList();
        //    patients = pb.GetAllPatients().Where(x =>x.MedicalAidNo.ToLower().Contains(term.ToLower())).Select(y => y.MedicalAidNo).ToList();

        //    return View("_SearchPatient", patients, JsonRequestBehavior.AllowGet);

        //}
        #endregion

        #region
        // [Authorize(Roles = "Pharmacist")]
        [Authorize]
        public PartialViewResult SearchDrugs(string drugpar = "")
        {
            var drugs = db.GetAll().ToList();
            return PartialView(db.GetAll().Where(x => x.DrugName.ToLower().Contains(drugpar.ToLower()) ||
                                                   x.DrugCategory.ToLower().Contains(drugpar.ToLower()) || 
                                                   drugpar == null).ToList());
        }
        #endregion


        #region
        //[Authorize(Roles="Doctor")]
        [Authorize]
        public PartialViewResult SearchStaffs(string staffpar = "")
        {
            var stuffs = rb.GetAllPatients().ToList();
            return PartialView(rb.GetAllPatients().Where(x => x.FullName.ToLower().Contains(staffpar.ToLower()) ||
                                                                    x.Surname.ToLower().Contains(staffpar.ToLower()) ||
                                                                    x.NationalId.ToLower().Contains(staffpar.ToLower()) ||
                                                                    x.Telephone.ToLower().Contains(staffpar.ToLower()) ||
                                                                    staffpar == null).ToList());
            
        }
        #endregion


        //#region
        //[Authorize]
        //public PartialViewResult SearchConsultation(string illpar = "")
        //{
        //    var cons = cb.GetConsultations().ToList();
        //    return PartialView(cb.GetConsultations().Where(x => x.illness.ToLower().Contains(illpar.ToLower()) ||
        //                                                        Convert.ToString(x.ConsultDate).Contains(illpar) ||
        //                                                        illpar == null).ToList());

        //}
        //#endregion


    }
}