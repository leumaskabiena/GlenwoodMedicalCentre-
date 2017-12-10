using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GlenwoodMed.BusinessLogic;
using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class ProceduresController : Controller
    {
        private DataContext db = new DataContext();
        ProcedureBusiness dba = new ProcedureBusiness();
        // GET: Procedures
        public ActionResult Index()
        {
            return View(db.Procedures.ToList());
        }

        // GET: Procedures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedure procedure = db.Procedures.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(procedure);
        }

        // GET: Procedures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procedures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "procedureId,procedureName,procedurePrice")] ProcedureView procedure, int[]procedureItem)
        {
            if (ModelState.IsValid)
            {
               
                dba.CreateProcedure(procedure, procedureItem);
                return RedirectToAction("Index").WithNotification(Status.Success, "Procedure created successfully");
            }

            return View(procedure).WithNotification(Status.Error, "Oops an error occured");
        }

        // GET: Procedures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Procedure procedure = db.Procedures.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(dba.EditProcedureView(id));
        }

        //[HttpPost]
        public PartialViewResult CustView()
        {
            var DropItemsFromDB = db.Drugs.ToList();
            ViewBag.DropDownItems = DropItemsFromDB;
            return PartialView("_cust");
        }
        // POST: Procedures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "procedureId,procedureName,procedurePrice")] ProcedureView PV,int[] procedureitems)
        {
            if (ModelState.IsValid)
            {
                dba.EditProcedurePost(PV, procedureitems);
                return RedirectToAction("Index").WithNotification(Status.Success, "Procedure created successfully");
            }
            else
            {
                return View(PV); 
            }
            
        }

        // GET: Procedures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedure procedure = db.Procedures.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(procedure);
        }

        // POST: Procedures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Procedure procedure = db.Procedures.Find(id);
            db.Procedures.Remove(procedure);
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
