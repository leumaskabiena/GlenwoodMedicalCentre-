using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMedicalCentre.Models;
using System;
using PagedList;
using PagedList.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class BookingController : Controller
    {

        DataContext da = new DataContext();
        private BookingBusiness b = new BookingBusiness();
        private PatientBusiness pb = new PatientBusiness();
        Email_serviceBusiness db = new Email_serviceBusiness();


        #region Display the main view
        [Authorize(Roles="Receptionist")]
        public ActionResult Index(int? page, int pageSize = 5)
        {
            List<PatientModel> pm = new List<PatientModel>();
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }


            int pageNumber = (page ?? 1);
            return View(pm.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Index(string patient, int? page, int pageSize = 5)
        {
            TempData["msg"] = "false";
           
            int pageNumber = (page ?? 1);

            if (string.IsNullOrEmpty(patient))
            {
                if (ModelState.IsValid)
                {
                    TempData["msg"] = "Emp";
                    return View(b.GetAllPat(patient).ToPagedList(pageNumber, pageSize));
                }

                else
                {
                    return View();
                }
            }

            else if (b.PatientExist(patient) == 0)
            {
                TempData["msg"] = "all";
                if (b.GetAllPat(patient).Count==0)
                {
                    TempData["msg"] = "true";
                }
                return View(b.GetAllPat(patient).ToPagedList(pageNumber, pageSize));

            }  
            else if (b.PatientExist(patient) >= 1)
            {
               
                return RedirectToAction("Details", new { id = b.PatientExist(patient) });
            }
            
            else
            {
                TempData["msg"] = "true";
                return View(b.GetAllPat(patient).ToPagedList(pageNumber, pageSize));
            }   
        }
        #endregion
        [Authorize(Roles = "Receptionist")]
        public PartialViewResult SBook(int? page, int pageSize = 5, string patient = "")
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            if (b.PatientExist(patient) != 0)
            {
                // return View("Patient_Book", new { id = b.PatientExist(patient) });

            }
            int pageNumber = (page ?? 1);


            var pm = b.GetAllRequest();
            PagedList<bookingPatient> model = new PagedList<bookingPatient>(pm, pageNumber, pageSize);
            return PartialView("_SearchBooking", model);
        }
        [Authorize(Roles = "Receptionist")]
        public ActionResult BookPatient(int id = 1)
        {
            return View(b.FindPatientDetails(id));
        }
        [Authorize(Roles = "Receptionist")]
        [HttpPost]
        public ActionResult BookPatient(bookingPatient bo)
        {
            try
            {
               // b.SaveBooking(bo);
                return RedirectToAction("ScheduleDate", "Calendar", new { id = Convert.ToInt32(System.Web.HttpContext.Current.Session["bookingId"]) });

            }
            catch
            {
                return View();
            }
        }



        #region Allow the Patient to Request Booking
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(bookingPatient bo)
        {
            try
            {
                // TODO: Add insert logic here
                b.resquestBooking(bo);

                TempData["msg"] = "Dear  " + bo.FullName + " your resquest is being Process and you will receive an email shortly";
                return RedirectToAction("succussfully", "Booking");
            }
            catch
            {
                TempData["Msg"] = "Dear  " + bo.FullName + "an error occured during the process please try again";
                return View();
            }
        }
        #endregion
        // GET: Booking
        #region Request Booking


        public ActionResult succussfully()
        {
            return View();
        }
        // GET: Booking/Details/5
        [Authorize(Roles = "Receptionist")]
        public ActionResult Details(int id )
        {
            //System.Web.HttpContext.Current.Session["ide"] = id;
            return View(b.FindPatientDetails(id));
        }
        [HttpPost]
        [Authorize(Roles = "Receptionist")]
        public ActionResult Details(bookingPatient m)
        {

            string dat = b.DateOfBooking(m.identification);
            if (b.GetBookingDetails(m.identification) == true)
            {
                //int id = Convert.ToInt16( System.Web.HttpContext.Current.Session["ide"] );
                ViewBag.Error = "Can't book a patient twice in a day";
                return View(b.FindPatientDetails(m.PatientIdKey));
            }
                 b.SaveBooking(m);
            //int d = Convert.ToInt32(System.Web.HttpContext.Current.Session["ide"]);
            return RedirectToAction("ScheduleDate", "Calendar", new { id = m.PatientIdKey });
        }
        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Booking/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        #endregion


        public ActionResult PatientBooking()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PatientBooking(string patient)
        {
            List<PatientModel> _patient;
            if (string.IsNullOrEmpty(patient))
            {
                _patient = pb.GetAllPatients();
            }

            else
            {
                _patient = pb.GetAllPatients().OrderBy(x => x.FullName).Where(x => x.FullName.ToLower().Contains(patient.ToLower().Trim())
                                                || x.Surname.ToLower().Contains(patient.ToLower().Trim())
                                                || x.Email.ToLower().Contains(patient.ToLower().Trim())
                                                || x.Telephone.ToLower().Contains(patient.ToLower().Trim())
                                                || x.NationalId.ToLower().Contains(patient.ToLower().Trim())
                                                || x.Sex.ToLower().Contains(patient.ToLower().Trim())
                                                || x.MedicalAidName.ToLower().Contains(patient.ToLower().Trim())
                                                || x.MedicalAidNo.Contains(patient.TrimEnd())
                                                || patient == null).ToList();
            }
            return View(_patient);
        }

        public FileStreamResult GetPDF()
        {//D:\Users\Yung_Ifie\Downloads\Documents\IS3012015_Assign.pdf
            FileStream fs = new FileStream("D:\\IS3012015_Assign.pdf", FileMode.Open, FileAccess.Read);
            //FileStream fs = new FileStream("c:\\PeterPDF2.pdf", FileMode.Open, FileAccess.Read);
            return File(fs, "application/pdf");
        }

       

        public ActionResult DoctorTime()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult DoctorTime(AvailDoctor m)
        {
            b.saveDoctorAv(m);
            //b.CreateReservation(m);
            return RedirectToAction("Index", "Calendar");
        }

        //booking for the user




    }
}

