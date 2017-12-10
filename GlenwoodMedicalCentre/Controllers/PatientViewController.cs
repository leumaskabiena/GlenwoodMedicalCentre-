using GlenwoodMed.BusinessLogic;
using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data;
using GlenwoodMedicalCentre.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class PatientViewController : Controller
    {
        PatientBusiness pb = new PatientBusiness();
        RegisterBusiness rg = new RegisterBusiness();
        PatientConsultationDetails pd = new PatientConsultationDetails();
        ConsultationBusiness cb = new ConsultationBusiness();

        // GET: PatientView
        [Authorize(Roles="Patient")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Patient")]
        public ActionResult MyProfile()
        {
            var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            return View(rg.GETeditUserMethod(user.ToString()));
        }

        #region View PAtient Consultation
        [Authorize]
        [Authorize(Roles = "Patient")]
        public ActionResult PatientConsultation()
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
                //Find Patient with the associated consultation 
                pd._Consultation = cb.GetConsultations().FindAll(x => x.PatientId == Convert.ToInt32(patientid.PatientId)).OrderByDescending(x => x.ConsultId).ToList();
                //Find patient and display details
                pd.Patient = pb.GetPatients().Find(x => x.PatientId == patientid.PatientId);
            }
            else
            {
                Response.Write("Invalid Entry This page is dependent on another page");
            }
            return View(pd);
        }
        #endregion
    }
}