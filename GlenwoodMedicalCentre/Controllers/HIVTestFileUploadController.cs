using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.BusinessLogic.Business;
using PagedList;
using System.IO;
using GlenwoodMed.Data;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class HIVTestFileUploadController : Controller
    {

        HIVTestUploadBusiness ee = new HIVTestUploadBusiness();
        // GET: HIVTestFileUpload
        public ActionResult Index(int PatientId)
        {
            //System.Web.HttpContext.Current.Session["Id"] = PatientId;
            var model = new HIVtestUpload()
            {
                patientName = ee.getpatientId(PatientId),
                PatientId = PatientId
            };
            return View(model);
        }

        public ActionResult Main()
        {
            var model = new HIVtestUpload();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Index(HIVtestUpload upload)
        {
            //int patientId = Convert.ToInt32(System.Web.HttpContext.Current.Session["Id"]);
            if(!ModelState.IsValid)
            {
                return View(upload);
            }
            ee.InsertM(upload, upload.PatientId);
            return RedirectToAction("DownaloadFiles", "HIVTestFileUpload", new { PatientId = upload.PatientId });
        }

        public ActionResult DownaloadFiles(int PatientId, int ?page, int pagesize=5)
        {
            var allfiles = ee.GetAllFiles(PatientId).OrderBy(x => x.patientName).ToList();
            if(Request.HttpMethod!="GET")
            {
                page = 1;
            }
            int Pnumber = (page ?? 1);
            List<HIVtestUpload> up = allfiles;
            PagedList<HIVtestUpload> model = new PagedList<HIVtestUpload>(up, Pnumber, pagesize);
            return View(model);
        }



        public ActionResult DownaloadPatientFiles(int? id)
        {
            Response.AppendHeader("Content-Disposition", "inline;ee.Find(id.Value).FileName.pdf");
            return new FileStreamResult(new MemoryStream(ee.Find(id.Value).File.ToArray()), "application/pdf");// ee.Find(id.Value).FileName);
       
        }
        /* public FileStreamResult GetPDF()
         {
             FileStream fs = new FileStream(Server.MapPath("inline;ee.Find(id.Value).FileName.pdf"), FileMode.Open, FileAccess.Read);
             return File(fs, "application/pdf");
         }*/

       // [RenderAsPDF]
        public ActionResult DownloadFile(int id)
        {

            using (var da = new DataContext())
            {
                var data = da.HIVPatientFiles.FirstOrDefault(m => m.Id == id);
                if (data == null) return HttpNotFound();
                Response.AppendHeader("Content-Disposition", "inline;ee.Find(id.Value).FileName.pdf");
                return new FileStreamResult(new MemoryStream(ee.Find(id).File.ToArray()), "application/pdf");// ee.Find(id.Value).FileName);
            }


            /*using (var db = new DataContext())
            {
                var data =
                    db.Documents.FirstOrDefault(m => m.ID == id);
                if (data == null) return HttpNotFound();
                Response.AppendHeader("content-disposition", "inline; filename=filename.pdf");
                return new FileStreamResult(new MemoryStream(data.Fisier.ToArray()), "application/pdf");
            }*/
        }

        //to be completed for viewing files online
      /*  public ActionResult GetPdf(string fileName)
        {
            var fileStream = new FileStream("~/Content/images/20141106142524.pdf" + fileName,
                                             FileMode.Open,
                                             FileAccess.Read
                                           );
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;
        }
        */

        // GET: HIVTestFileUpload/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HIVTestFileUpload/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HIVTestFileUpload/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HIVTestFileUpload/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HIVTestFileUpload/Edit/5
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

       
        // POST: HIVTestFileUpload/Delete/5
       // [HttpPost]
        public ActionResult Delete(int id)
        {
           
                ee.PostDeleteM(id);
                return RedirectToAction("DownaloadFiles");
           
        }
    }
}
