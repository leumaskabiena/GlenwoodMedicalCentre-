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

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class Email_servicesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Email_services
        public ActionResult Index()
        {
            return View(db.email_services.ToList());
        }

        // GET: Email_services/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email_services email_services = db.email_services.Find(id);
            if (email_services == null)
            {
                return HttpNotFound();
            }
            return View(email_services);
        }

        // GET: Email_services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Email_services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "To,Subject,Body")] Email_services email_services)
        {
            if (ModelState.IsValid)
            {
                db.email_services.Add(email_services);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(email_services);
        }

        // GET: Email_services/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email_services email_services = db.email_services.Find(id);
            if (email_services == null)
            {
                return HttpNotFound();
            }
            return View(email_services);
        }

        // POST: Email_services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "To,Subject,Body")] Email_services email_services)
        {
            if (ModelState.IsValid)
            {
                db.Entry(email_services).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(email_services);
        }

        // GET: Email_services/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email_services email_services = db.email_services.Find(id);
            if (email_services == null)
            {
                return HttpNotFound();
            }
            return View(email_services);
        }

        // POST: Email_services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Email_services email_services = db.email_services.Find(id);
            db.email_services.Remove(email_services);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
