using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using GlenwoodMed.BusinessLogic;
using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data;
using PagedList;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using GlenwoodMedicalCentre.Models;
using System.Collections;
using RazorPDF;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class ConsultationsController : Controller
    {
        
       
        
        PatientConsultationDetails pd = new PatientConsultationDetails();
        PatientBusiness pb = new PatientBusiness();
        ConsultationBusiness db = new ConsultationBusiness();
        ConsultationDrugsBusiness bis = new ConsultationDrugsBusiness();
        DrugRespo drugrep = new DrugRespo();
        ConsultationDetails ConsultationDetails = new ConsultationDetails();
       DataContext da=new DataContext();
       InformationBusiness ib = new InformationBusiness();

        // GET: Consultations
        #region Consultation Main Index
        [Authorize(Roles = "Doctor")]
        public ActionResult MainIndex()
        {

            return View();
        }
        #endregion

        public ActionResult PrintView()
        {
            DataContext context = new DataContext();
            var userStore = new UserStore<GlenwoodMed.Data.ApplicationUser>(context);
            var userManager = new UserManager<GlenwoodMed.Data.ApplicationUser>(userStore);

            var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if (user != null)
            {
                var rcontext = new IdentityDbContext();
                var allUsers = userManager.Users.ToList();
                var getid = allUsers.Find(x => x.Id == user.ToString());
                var patientid = pb.GetPatients().Find(x => x.NationalId == getid.NationalId.ToString());

                var lastpresc = da.Consultations.ToList().FindLast(x => x.PatientId == patientid.PatientId);

                ViewBag.Id = lastpresc.ConsultId;
                return View();
            }

            else
            {
                return View();
            }
        }


        public PartialViewResult SConsult(int? page, int pageSize = 5, string conspar = "")
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            //int pageSize = 5;
            int pageNumber = (page ?? 1);
            List<PatientModel> pm = pb.GetAllPatients().Where(x => x.FullName.ToLower().Contains(conspar.ToLower())
                                                           || x.Surname.ToLower().Contains(conspar.ToLower())
                                                           || x.NationalId.ToLower().Contains(conspar.ToLower())
                                                           || conspar == null).ToList();
            PagedList<PatientModel> model = new PagedList<PatientModel>(pm, pageNumber, pageSize);
            //return View("MainIndex", model);
            return PartialView("_Consultation", model);
        }

        #region Consultation Index
        public ActionResult Index()
        {
            int patId = Convert.ToInt16(System.Web.HttpContext.Current.Session["D_patientId"]);

            var name = pb.GetPatients().ToList().Find(x => x.PatientId == patId);

            ViewBag.PatientName = name.FullName.ToString().ToUpper();
            return View(db.GetAllConsultations(name.PatientId));
        }
        #endregion

        #region Get Create Consultation
        [Authorize(Roles = "Doctor")]
        public ActionResult Create(int id)
        {
            ConsultationView cv = new ConsultationView();
           // List<string> i = Session["illness"].ToString();
           
           // foreach(var add in Convert.ToInt32(Session["illness"]))
           // {
           //     i.Add(add);
           // }
            

           // illness = yourInt.ToString().Select(o=> Convert.ToInt32(o)).ToArray()
           //  illness=Array.ConvertAll(Session["illness"]);
           //lstValue= Session["lstValue"] ;
            //ViewBag.Selected = new MultiSelectList(da.Symptomses.ToList(), "Symptomsid", "symptomsname", lstValue);
           
           
                
                var patient = da.Patients.ToList().Find(x => x.PatientId == id);
                var name = pb.GetAllPatients().Find(x => x.userId == id);
                if (patient != null)
                {
                    cv.procedures = new List<ConsultationView.procedure>();
                    
                    Session["newid"] = id;
                    //cv = db.CreateMethod(cv, id);
                    
                    //cv = new ConsultationView()
                    //{
                        cv.PatientId = id;
                        cv.patientfullname = patient.FullName + " " + patient.Surname;
                        cv.FileName = patient.FileName;
                        cv.FileType = patient.FileType;
                        cv.resultFile = patient.File;
                        cv.Description = patient.PatientAllergy;
                    //};
                    cv.CreateCusts(1);
                    cv.CreateProcedure(1);
                return View(cv);
                }
                else
                {
                    return RedirectToAction("MainIndex")
                        .WithNotification(Status.Error, "Sorry We could not find the patient you're looking for ");
                }
            
          
            
        }

        [HttpPost]
        public ActionResult DispenseDrug(DispenseDrug DD, string id)
        {
            Consultation consult = da.Consultations.ToList().Find(x => x.ConsultId == DD.ConsultId);

            foreach (var drug in consult.CustLis)
            {
                Drug dg = drugrep.GetAll().Find(x => x.DrugName == drug.DrugId);
                dg.DrugQuantity -= drug.Quantity;
                drugrep.Update(dg);
            }
            return RedirectToAction("ViewDrugsConsultation").WithNotification(Status.Success, "Dispensed Drugs Sucessfully");
        }

        public JsonResult Search(string term)
        {
            var result = (from r in da.Drugs
                          where r.DrugName.ToLower().Contains(term.ToLower())
                          select new
                          {
                              r.DrugId,
                              r.DrugName,
                              r.DrugType
                          }).Distinct();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchProccedure(string term)
        {
            var result = (from r in da.Procedures
                          where r.procedureName.ToLower().Contains(term.ToLower())
                          select new
                          {
                              r.procedureName
                          }).Distinct();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProcedureView()
        {
            return PartialView();
        }
        //public void MarkAsAdded(User user)
        //{
        //    da.ChangeObjectState(user, System.Data.EntityState.Added);
        //} 
        public ActionResult CreateSymptoms(int UserId)
        {
            System.Web.HttpContext.Current.Session["4rmCreateC"] = UserId;

            return PartialView();
        }
        public ActionResult CreateIllness(int UserId,int[]Illnesshref)
        {
            System.Web.HttpContext.Current.Session["4rmCreateC"] = UserId;

            return PartialView();
        }

        [HttpPost]
        public ActionResult CreateIllness(string name)
        {
            int UserId = Convert.ToInt32(System.Web.HttpContext.Current.Session["4rmCreateC"]);
            db.AddIllness(name);
            return RedirectToAction("Create", new { id = UserId }).WithNotification(Status.Success, "Illness has been created succesfully");
        }
      
        #endregion
       

        #region Post Add Consultation Controller
        [HttpPost]
        public ActionResult CreateSymptoms(string name)
        {
            int UserId = Convert.ToInt32(System.Web.HttpContext.Current.Session["4rmCreateC"]);
            db.AddSymptoms(name);
            return RedirectToAction("Create", new { id = UserId}).WithNotification(Status.Success, "Symptoms has been created succesfully");
        }

        public ActionResult UpdatePrice(string ConsultId, int usernewid)
        {
            var id = pb.GetPatients().Find(x => x.PatientId == usernewid);
            var consultid = db.GetConsultations().Find(x => x.ConsultId == ConsultId);
            ViewBag.name = id.FullName + " " + id.Surname;
            ViewBag.balance = consultid.TotalPrice - consultid.Amountpaid;
            ViewBag.Total = consultid.TotalPrice;
            Session["useroldnewid"] = usernewid;
            Session["ConsultId"] = ConsultId;
            return PartialView();
        }
        [HttpPost]
        public ActionResult UpdatePrice(decimal price)
        {
            string UserId = Convert.ToString(System.Web.HttpContext.Current.Session["ConsultId"]);
            string usernewid = Convert.ToString(System.Web.HttpContext.Current.Session["useroldnewid"]);
            db.updatePrice(UserId, price);
            return RedirectToAction("ViewPatientConsultation", new { id = usernewid })
                .WithNotification(Status.Success, "Updated Price Succesfully");
        }
        public ActionResult PrintConsultation(string ConsultId)
        {
            DataContext db = new DataContext();
            var con = new Consultation();

            // pass in Model, then View name
            var pdf = ib.GetAllConsultations().ToList().Find(x => x.ConsultId == ConsultId);

            //Find Patient with the associated consultation 
            pd.ConsultationV = ib.GetAllConsultations().ToList().Find(x => x.ConsultId == ConsultId);
            //Find patient and display details
            pd.Patient = pb.GetPatients().Find(x => x.PatientId == pdf.PatientId);

            // With no Model and default view name.  Pdf is always the default view name
            //return new PdfResult();
            return new PdfResult(pd, "PrintConsultation");
        }

        public ActionResult PrintPresc(string ConsultId)
        {
            DataContext db = new DataContext();
            var con = new Consultation();

            // pass in Model, then View name
            //var pdf = db.Consultations.ToList().Find(x => x.ConsultId == ConsultId);

            //Find Patient with the associated consultation 
            Consultation ob= db.Consultations.ToList().Find(x => x.ConsultId == ConsultId);
            //Find patient and display details
            //pd.Patient = pb.GetPatients().Find(x => x.PatientId == pdf.PatientId);
            // With no Model and default view name.  Pdf is always the default view name
            //return new PdfResult();
            return new PdfResult(ob, "PrintPrescription");
        }

        public ActionResult PrintInvoice(string ConsultId)
        {
            DataContext db = new DataContext();
            var con = new Consultation();

            // pass in Model, then View name
            var pdf = db.Consultations.ToList().Find(x => x.ConsultId == ConsultId);

            //Find Patient with the associated consultation 
            pd.Consultation = db.Consultations.ToList().Find(x => x.ConsultId == ConsultId);
            //Find patient and display details
            pd.Patient = pb.GetPatients().Find(x => x.PatientId == pdf.PatientId);

            // With no Model and default view name.  Pdf is always the default view name
            //return new PdfResult();
            return new PdfResult(pd, "PrintInvoice");
        }

        [Authorize]
        public ActionResult Print(string ConsultId)
        {
            ViewBag.ConsultId = ConsultId;
            return View();
        }

        public ActionResult PrintPrescription(string ConsultId)
        {
            DataContext db = new DataContext();
            var con = new Consultation();

            // pass in Model, then View name
            var pdf = db.Consultations.ToList().Find(x => x.ConsultId == ConsultId);

            //Find Patient with the associated consultation 
            // pd.Consultation = db.Consultations.ToList().Find(x => x.ConsultId == ConsultId);
            //Find patient and display details
            // pd.Patient = pb.GetPatients().Find(x => x.PatientId == pdf.PatientId);

            Consultation obConsultation = db.Consultations.ToList().Find(x => x.ConsultId == ConsultId);
            // With no Model and default view name.  Pdf is always the default view name
            //return new PdfResult();
            return new PdfResult(obConsultation, "PrintPrescription");
        }

        // POST: Consultation/Create
        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public ActionResult AddConsultation(ConsultationView cv, int[] lstValue, string[] PresribedMed, int[] Test, int[] Testtype, int[] illness, int[] Procedures)
        {
             
            #region Commented code for Slecting multiple 

            int id = Convert.ToInt32(Session["newid"]);
              try
                {


                    foreach (var iteem in cv.Custs)
                    {
                        if ((iteem.DrugId != null) && (iteem.Dosage != null) && (iteem.Quantity != 0))
                        {

                        }
                    }


                    //Method to add consultation 
                    db.AddConsultation(cv, id, lstValue, PresribedMed, Testtype, illness, Procedures);

                    //return to this view
                    return RedirectToAction("MainIndex", "Consultations").WithNotification(Status.Success, "Consultation Created Successfully");
                }

                catch (DataException e)
                {
                    return RedirectToAction("MainIndex", "Consultations").WithNotification(Status.Error, e.Message + " See Admin for more details");
                }
            
            #endregion


        }

        #endregion

        #region Get Add Drugs to consultation
        //[Authorize(Roles = "Pharmacists")]
        public ActionResult AddDrugsToConsult(string id)
        {
            System.Web.HttpContext.Current.Session["ToConsultId"] = id;

            return View(db.GetDispenseDrugs(id));
        }
        #endregion


        #region View PAtient Consultation
        [Authorize]
        [Authorize(Roles = "Doctor")]
        public ActionResult ViewPatientConsultation(int? id)
        {
            if (id != 0)
            {
                //Find Patient with the associated consultation 
                pd._Consultation = db.GetConsultations().FindAll(x => x.PatientId == id).OrderByDescending(x => x.ConsultId).ToList();
                //Find patient and display details
                pd.Patient = pb.GetPatients().Find(x => x.PatientId == id);
            }
            else
            {
                Response.Write("Invalid Entry This page is dependent on another page");
            }
            return View(pd);
        }
        #endregion
        
        
        #region
        //TODO: Auto Complete Search
        public JsonResult GetCustomers(string term)
        {
            //Get the cutomers details where the parameter(term) starts with the customers name
            List<string> customers;
            customers = da.Patients.Where(x => x.FullName.StartsWith(term)).Select(y => y.FullName).ToList();


            //Return it using Javascript
            return Json(customers, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region View Patient Drugs to a PartialView
        // TODO: View Patients Consultation Drugs
        public ActionResult ViewPatientDrugs(int? id)
        {

            if (id != null)
            {
                //var user = db.DetailsMethod(id);
                //var userma = pb.GetAllPatients().Find(x => x.userId == user.UserId);

                //ConsultationDetails._ConsultationDrugs = bis.ConsultationDrugs().FindAll(x => x.ConsultationId == id);
                //ConsultationDetails._Consultation = db.DetailsMethod(id);
                //ConsultationDetails._Consultation.Fullnamepar = userma.FullName + " " + userma.Surname;
                //decimal total = 0;
                //List<ConsultationDrug> consultd = bis.ConsultationDrugs().ToList().FindAll(x => x.ConsultationId == id);
                //foreach (var VARIABLE in consultd)
                //{
                //    total += VARIABLE.Price;
                //}
                //ViewBag.total = total;
                return View(ConsultationDetails);
            }

            return RedirectToAction("ViewPatientConsultation");

        }

        #endregion

        #region Get View Drug Consultation
        // TODO: Get Drug Consultation
        public ActionResult ViewDrugsConsultation()
        {
            int Id = Convert.ToInt16(System.Web.HttpContext.Current.Session["consultid"]);
            if (Id == 0)
            {
                pd._Consultation = da.Consultations.ToList();
               // pd.Patient =new  Patient();
                //var consultation = db.GetConsultations().Find(x => x.ConsultId == Id);
                //decimal total = 0;

                //ConsultationDetails._Consultation = db.DetailsMethod(Id);
                //var user = pb.GetAllPatients().Find(x => x.userId == ConsultationDetails._Consultation.UserId);
                //ViewBag.userman = user.FullName + " " + user.Surname;
                //ConsultationDetails._ConsultationDrugs = bis.ConsultationDrugs().ToList().FindAll(x => x.ConsultationId == Id);
                //foreach (var item in bis.ConsultationDrugs().ToList().FindAll(x => x.ConsultationId == Id))
                //{
                //    total += item.Price;
                //}

                //ViewBag.total = total;
                var CollectionDrugs = da.Consultations.ToList().FindAll(x=>x.collected==false);

                return View(CollectionDrugs);

            }

            else
            {
                return RedirectToAction("Index", "Patient");
            }

        }
        #endregion

        #region Get Delete Drug from consultation
        // TODO: Delete Drugs from consultation
        public ActionResult DeleteDrugsConsultation(string id)
        {
            bis.GetDeleteDrugFromConsultation(id);
            TempData["msg"] = "Data has been Deleted Succesfully";

            return RedirectToAction("ViewDrugsConsultation");
        }
        #endregion

        #region Post Delete Drug from consultation
        //TODO: Delete drug from consultation
        [HttpPost]
        public ActionResult DeleteDrugsConsultation(int id, ConsultationDrugView cv)
        {
            int drugid = Convert.ToInt16(System.Web.HttpContext.Current.Session["D_ID"]);
            int quantity = Convert.ToInt16(System.Web.HttpContext.Current.Session["D_Quantity"]);
            if ((drugid != 0) && (quantity != 0))
            {
                // TODO: Add delete logic here
                bis.PostDeleteMethod(drugid, id, quantity);
                TempData["Msg"] = "Data has been deleted succeessfully";
                return RedirectToAction("MainIndex");
            }
            else
            {
                return PartialView();
            }
        }
        #endregion


        #region Get Details
        public ActionResult Details(int id)
        {
             id = Convert.ToInt32(Session["userid"]);
             var re = db.GetConsultations().ToList().FindLast(x => x.PatientId == id);
            var m = db.DetailsMethod(re.ConsultId);
            var menu = pb.GetPatients().Find(x => x.PatientId == m.PatientId);
            ViewBag.getname = menu.FullName;

            return PartialView(db.DetailsMethod(id));
        }
        #endregion

        public ActionResult Last2Consultation(int? patientid)
        {
            patientid = Convert.ToInt32(Session["newid"]);
            return PartialView(db.Last2Consultations(patientid));
        }

        public ActionResult Procedures(ConsultationView Model)
        {
            Model.procedures = new List<ConsultationView.procedure>();
            List<Procedure> procedures=da.Procedures.ToList();
            ConsultationView.procedure proprocedure = new ConsultationView.procedure();
            foreach (var item in procedures)
            {
                proprocedure.procedureid = item.procedureId;
                proprocedure.procedurename = item.procedureName;
                proprocedure.procedureprice = item.procedurePrice;
                Model.procedures.Add(proprocedure);
            }
            
            return PartialView(Model);
        }
        [HttpPost]
        public ActionResult Procedures(ConsultationView Model, int[]procedures)
        {
            int Uid=Convert.ToInt32(Session["newid"]);
            ConsultationView newcv=new ConsultationView();
            ConsultationView.procedure ob=new ConsultationView.procedure();
            foreach (var item in procedures)
            {
                Procedure pro=da.Procedures.Find(item);
                ob.procedureid =pro.procedureId;
                ob.procedurename = pro.procedureName;
                ob.procedureprice = pro.procedurePrice;
                Model.procedures.Add(ob);
            }
            TempData["tempModel"] = Model;
            return RedirectToAction("Create",new { id = Model.PatientId});
        }

    }
}