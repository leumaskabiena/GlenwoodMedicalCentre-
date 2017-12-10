using GlenwoodMed.BusinessLogic;
using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMedicalCentre.Models;
using System;
using PagedList.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using RazorPDF;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using MoreLinq;
//using PagedList;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class PatientController : Controller
    {
        RegisterBusiness rg = new RegisterBusiness();
        DependentBusiness db = new DependentBusiness();
        BookingBusiness bb = new BookingBusiness();
        PatientBusiness pb = new PatientBusiness();
        StatisticsBusiness sb = new StatisticsBusiness();
        RolesBusiness rb = new RolesBusiness();
        //TestResultBusiness tb = new TestResultBusiness();
        HIVTestResultBusiness htb = new HIVTestResultBusiness();
        UploadBusiness bu = new UploadBusiness();
        ReportModel rm = new ReportModel();
        // GET: Patient
        [Authorize]
        public ActionResult Index(int? page, int? bookingId, int pageSize = 5, string patient = "")
        {

            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);

            if (bookingId.HasValue)
            {
                bb.EndConsultaion(bookingId.Value);
            }

            ViewData["CountPatients"] = bb.CountMethod().ToString();
            ViewBag.Info = bb.Consulted();
            ViewData["N_count"] = bb.NotConsulted();

            //List<PatientModel> pm = pb.GetAllPatients();
            var bop = bb.GetAllBookings().Where(x => x.Status == 0 && Convert.ToDateTime(x.start_date).Date.Day == DateTime.Now.Day
                                                                        && Convert.ToDateTime(x.start_date).Date.Month == DateTime.Now.Month
                                                                        && Convert.ToDateTime(x.start_date).Date.Year == DateTime.Now.Year).ToList();

            List<bookingPatient> bp = bop.OrderBy(x => x.time).Where(x => x.FullName.ToLower().Contains(patient.ToLower())
                                                || x.Telephone.ToLower().Contains(patient.ToLower())
                                                || x.Email.ToLower().Contains(patient.ToLower())
                                                || patient == null).ToList();

            PagedList<bookingPatient> model = new PagedList<bookingPatient>(bp, pageNumber, pageSize);
            return View("Index", bp.ToPagedList(pageNumber, pageSize));
        }

        //[HttpPost]
        //[Authorize]
        //public ActionResult Index(string patient)
        //{
        //    List<bookingPatient> _patient;
        //    if(string.IsNullOrEmpty(patient))
        //    {
        //        _patient = bb.GetAllBookings().Where(x => x.Status == 0 && Convert.ToDateTime(x.date).Day == DateTime.Now.Day).ToList();
        //    }

        //    else
        //    {
        //        _patient = bb.GetAllBookings().Where(x => x.Status == 0 && Convert.ToDateTime(x.date).Day == DateTime.Now.Day).OrderBy(x => x.FullName).Where(x => x.FullName.ToLower().Contains(patient.ToLower())
        //                                        //|| x.Surname.ToLower().Contains(patient.ToLower())
        //                                        || x.Telephone.ToLower().Contains(patient.ToLower())
        //                                        || x.Email.ToLower().Contains(patient.ToLower())
        //                                        //|| x.NationalId.ToLower().Contains(patient.ToLower())
        //                                        //|| x.Sex.ToLower().Contains(patient.ToLower())
        //                                        //|| x.MedicalAidName.ToLower().Contains(patient.ToLower())
        //                                        //|| x.MedicalAidNo.ToLower().Contains(patient.ToLower())
        //                                        || patient == null).ToList();
        //    }
        //    return View(_patient);
        //}

        //public ActionResult Index(int? page, int pageSize = 5, string patient = "")
        //{
        //    var pb = new PatientBusiness();

        //    ViewBag.Count = pb.CountMethod().ToString();

        //    if (Request.HttpMethod != "GET")
        //    {
        //        page = 1;
        //    }

        //    //int pageSize = 5;
        //    int pageNumber = (page ?? 1);

        //    var myp = pb.GetAllPatients().OrderBy(x => x.FullName).Where(x => x.FullName.ToLower().Contains(patient.ToLower())
        //                                        || x.Surname.ToLower().Contains(patient.ToLower())
        //                                        || x.Telephone.ToLower().Contains(patient.ToLower())
        //                                        || x.NationalId.ToLower().Contains(patient.ToLower())
        //                                        || x.Sex.ToLower().Contains(patient.ToLower())
        //                                        || x.MedicalAidName.ToLower().Contains(patient.ToLower())
        //                                        || x.MedicalAidNo.ToLower().Contains(patient.ToLower())
        //                                        || patient == null).ToList();


        //    List<PatientModel> pm = myp; // pb.GetAllPatients();
        //    PagedList<PatientModel> model = new PagedList<PatientModel>(pm, pageNumber, pageSize);
        //    //return View("Index", myp.ToPagedList(pageNumber, pageSize));
        //    return View(model);
        //}

        [Authorize]
        public ActionResult PrintHistory(int PatientId)
        {
            ConsultationBusiness cb = new ConsultationBusiness();
            var con = new Consultation();

            PatientConsultationDetails pd = new PatientConsultationDetails();
            // pass in Model, then View name

            //Find Patient with the associated consultation 
            pd._Consultation = cb.GetConsultations().FindAll(x => x.PatientId == PatientId).OrderByDescending(x => x.ConsultId).ToList();
            //Find patient and display details
            pd.Patient = pb.GetPatients().Find(x => x.PatientId == PatientId);
            //pd._Xray = tb.GetAll().Where(x => x.PatientId == PatientId).ToList();
            pd._HIV = htb.GetAllTest().Where(x => x.PatientId == PatientId).ToList();
            //rm._HIV = 
            // With no Model and default view name.  Pdf is always the default view name
            //return new PdfResult();
            return new PdfResult(pd, "PrintHistory");
        }

        public ActionResult Main()
        {
            ViewBag.Info = bb.Consulted();
            ViewData["N_count"] = bb.NotConsulted();
            return View();
        }

        public ActionResult Test()
        {
            return PartialView("_AgeGroup");
        }

        public ActionResult List_info()
        {
            return View();
        }
        public PartialViewResult _ConsultedPatients(int? page, int pageSize = 5, string patientpar = "")
        {

            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            //int pageSize = 5;
            int pageNumber = (page ?? 1);
            var bop = bb.GetAllBookings().Where(x => Convert.ToDateTime(x.date).Day == DateTime.Now.Day
                                                                        && Convert.ToDateTime(x.date).Month == DateTime.Now.Month
                                                                        && Convert.ToDateTime(x.date).Year == DateTime.Now.Year).OrderBy(x => x.FullName).DistinctBy(x => x.FullName).ToList();
            int count = 0;
            foreach (var c in bop)
            {
                count++;
            }

            ViewBag.Count = count.ToString();

            if(patientpar != "")
            {
                DateTime sin = Convert.ToDateTime(patientpar);
                //List<bookingPatient> bp = bop.OrderBy(x => x.time).Where(x => Convert.ToDateTime(x.date).ToString("MM/dd/yyyy").Equals(Convert.ToDateTime(patientpar).ToString("MM/dd/yyyy"))
                //                                || patientpar == null).ToList();

                //List<bookingPatient> bp = bop.FindAll(x => DateTime.Equals(Convert.ToDateTime(x.start_date), sin)).ToList();
                List<bookingPatient> bp = bop.FindAll(x => DateTime.Equals(Convert.ToDateTime(x.start_date), sin)).ToList();

                PagedList<bookingPatient> model = new PagedList<bookingPatient>(bp, pageNumber, pageSize);
                return PartialView("_ConsultedPatients", model);
            }
            
            else
            {
                PagedList<bookingPatient> model = new PagedList<bookingPatient>(bop, pageNumber, pageSize);
                return PartialView("_ConsultedPatients", model);
            }   
        }

        public PartialViewResult _IncomeChart()
        {
            return PartialView("_Income");
        }

        public PartialViewResult _AgeChart()
        {
            return PartialView("_AgeGroup");
        }

        public PartialViewResult _ConsultationsChart()
        {
            return PartialView("_Consultations");
        }

        public JsonResult Consult()
        {
            return new JsonResult { Data = sb.ReportData(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetPatients(string term)
        {
            var pb = new PatientBusiness();
            DataContext da = new DataContext();
            List<string> myp;
            myp = da.Patients.Where(x => x.Surname.StartsWith(term)).Select(x => x.Surname).ToList();

            return Json(myp, JsonRequestBehavior.AllowGet);
        }

        // GET: Patient/EditPatient
        [Authorize]
        public ActionResult EditPatient(int? PatientId)
        {
            System.Web.HttpContext.Current.Session["DpId"] = PatientId;

            return View(pb.GETeditMethod(PatientId));
        }

        // POST: Patient/EditPatient
        [HttpPost]
        [Authorize]
        public ActionResult EditPatient(PatientModel objRegisterModel)
        {
            try
            {
                // TODO: Add Edit logic here

                int user = Convert.ToInt16(System.Web.HttpContext.Current.Session["DpId"]);

                pb.PostEditMethod(objRegisterModel);
                return RedirectToAction("Index", "Patient");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/ViewPatient
        [Authorize]
        public ActionResult ViewPatient(int? PatientId)
        {
            if (PatientId != 0)
            {
                var UserProfs = pb.GetPatients().Find(x => x.PatientId == PatientId.Value);

                System.Web.HttpContext.Current.Session["DpId"] = PatientId;

                PatientDetails pd = new PatientDetails();

                pd._myuser = pb.GETeditMethod(PatientId);
                pd._dependent = db.GetDependents().FindAll(x => x.PatientId == UserProfs.PatientId).ToList();
                pd._file = bu.GetPatientNameFiles(PatientId.Value);
                //pd._file = bu.GetAllPatientFiles().FindAll(x => x.PatientId == UserProfs.PatientId);
                return View("ViewPatient", pd);

            }

            else
            {
                return RedirectToAction("Index", "Patient");
            }

        }

        // GET: Default/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patient/RegisterPatient
        [Authorize]
        public ActionResult RegisterPatient()
        {
            var patientmodel = new PatientModel();

            patientmodel.CreateAddresses(2);
            return View(patientmodel);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult> RegisterPatient(PatientModel objRegisterModel, string Gender, string Status, string Id, string Title)
        {
            var registerbusiness = new RegisterBusiness();
            var rol = new RolesBusiness();
            //string userName = objRegisterModel.Email.ToString();

            if (registerbusiness.FindUser(objRegisterModel.Email, AuthenticationManager) || registerbusiness.FindUserId(objRegisterModel.NationalId))
            {
                ModelState.AddModelError("", "User already exists");
                return View(objRegisterModel);
            }

            //if (registerbusiness.FindUserId(objRegisterModel.NationalId))
            //{
            //    ModelState.AddModelError("", "User already exists");
            //    return View(objRegisterModel);
            //}

            var pass = Guid.NewGuid().ToString().Substring(0, 8);
            string Patient_No = "GM" + pass.ToString().ToUpper();

            var result = await registerbusiness.RegisterPa(objRegisterModel, AuthenticationManager, Gender, Status, Title, Patient_No);
            pb.CreateMethod(objRegisterModel, Gender, Status, Title, Patient_No);

            if (result)
            {
                //string error = "";
                //rol.AddRoleToUser(Id, userName, error);
                //System.Web.HttpContext.Current.Session["PatientId"] = objRegisterModel.Email.ToString();
                return RedirectToAction("Create", "PatientDependent");
                //return RedirectToAction("Index", "Booking");
            }
            else
            {
                ModelState.AddModelError("", result.ToString());
            }

            return View(objRegisterModel);
        }

        // POST: Patient/RegisterPatient
        //[HttpPost]
        //[Authorize]
        //public ActionResult RegisterPatient(PatientModel rm, string Gender, string Status, string Title)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        if (rg.FindUser(rm.Email, AuthenticationManager))
        //        {
        //            ModelState.AddModelError("", "User already exists");
        //            return View(rm);
        //        }

        //        rg.RegisterPatient(rm, AuthenticationManager, Gender, Status, Title);

        //        pb.CreateMethod(rm, Gender, Status, Title);

        //        //System.Web.HttpContext.Current.Session["PatientId"] = rm.Email.ToString();

        //        return RedirectToAction("Create", "PatientDependent");
        //    }

        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("Error", ex.Message);
        //        return View(rm);
        //    }
        //}

        // GET: Patient/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            pb.GETeditMethod(id);
            return View();
        }

        // POST: Patient/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int? id, PatientModel rm)
        {
            try
            {
                // TODO: Add update logic here
                pb.PostEditMethod(rm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            pb.GETdeleteMethod(id);
            return View();
        }

        // POST: Patient/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                pb.PostDeleteMethod(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}