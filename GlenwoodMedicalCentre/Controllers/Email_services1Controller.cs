using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using System.Net.Mail;
using System.IO;
using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class Email_services1Controller : Controller
    {
        Email_serviceBusiness db = new Email_serviceBusiness();

        // GET: Email
       // [Authorize]
        public ActionResult Index()
        {
            return View(db.GetallEmail());

        }

        // GET: Email/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View(db.EmailDetails(id));
        }

        // GET: Email/Create
         [Authorize]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Email/Create
        [HttpPost]
        //[Authorize]
        public ActionResult Create(Email_serviceViewModel email_services_)//, HttpPostedFileBase fileUploader)
        {
            try
            {
                email_services_.StaffName = User.Identity.Name;
                // TODO: Add insert logic herezzZZZ
                db.createemail(email_services_);//, fileUploader);
                TempData["msg"] = "Email was sent successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Email/Edit/5
        public ActionResult Edit(int id)
        {
            // return View(db.GETeditemail(id));
            return View();
        }

        // POST: Email/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, Email_serviceViewModel emailcollection)
        {
            try
            {
                // TODO: Add update logic here
                // db.PostEditMethod(emailcollection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Email/Delete/5
         [Authorize]
        public ActionResult Delete(int id)
        {
            return View(db.GETdeleteMethod(id));
        }

        // POST: Email/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id, Email_serviceViewModel ee)
        {
            try
            {
                db.PostDeleteMethod(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
