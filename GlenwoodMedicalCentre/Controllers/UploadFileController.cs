
using GlenwoodMedicalCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using System.IO;
using PagedList;
using GlenwoodMed.BusinessLogic.Business;
using System.Web.Mvc.Html;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class UploadFileController : Controller
    {
        private DataContext db = new DataContext();
        UploadBusiness bu = new UploadBusiness();

        //getting your httpPostedfilebase method from your class
        // GET: /UploadFile/
        [Authorize]
        public ActionResult Index(int patientId)
        {
            var name = db.Patients.ToList().Find(x => x.PatientId == patientId);
            System.Web.HttpContext.Current.Session["Id"] = patientId;
            var model = new FileUploadDBModel()
            {
                patientName = name.FullName.ToUpper() + " " + name.Surname.ToUpper()
            };
            return View(model);
        }

        [Authorize]
        public ActionResult Main()
        {
            var model = new FileUploadDBModel();
            return PartialView(model);
        }

        //using your called HttpPostedfileBase to upload file
        [HttpPost]
        [Authorize]
        public ActionResult Index(FileUploadDBModel model)
        {
            int PatientI = Convert.ToInt32(System.Web.HttpContext.Current.Session["Id"]);
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            #region
            //PatientFile fileUploadModel = new PatientFile();
            ////add loop for multiple file upload at same time
            //foreach(var item in model.File)
            //{
            //    byte[] uploadfile = new byte[item.InputStream.Length];
            //    item.InputStream.Read(uploadfile, 0, uploadfile.Length);

            //    fileUploadModel.FileName = item.FileName;
            //    fileUploadModel.File = uploadfile;

            //    db.PatientFiles.Add(fileUploadModel);
            //    db.SaveChanges();
            //}
            #endregion
            bu.InsertMethod(model, PatientI);
           //return Content("File successfull Uploaded");
           return RedirectToAction("Download", "UploadFile");
        }

        //will return the list of uploaded files from the database. 
        [Authorize]
        public ActionResult Download(int? page)
        {
            var allfiles = bu.GetAllFiles().OrderBy(x => x.patientName).ToList();

            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(allfiles.ToPagedList(pageNumber, pageSize));
            //return View(bu.GetAllFiles());
        }

        //FileDownload’ will receive the call from Download action and return the File type data and user will notice download progress in the browse
        //it also allow a user to view file but not all the browse
        [Authorize]
         public ActionResult FileDownload(int? id)
        {
            #region
            //byte[] fileData;
            // string fileName;
            // var fileRecord = db.PatientFiles.Find(id);
            // var cd = new System.Net.Mime.ContentDisposition
            // {
            //     // fileData = (byte[])fileRecord.File.ToArray(),
            //     FileName = fileRecord.FileName,

            //     Inline = false,
            // };

            // Response.AppendHeader("Content-Disposition", cd.ToString());
            // return new FileStreamResult(new MemoryStream(fileRecord.File), fileRecord.FileName);
            #endregion
            Response.AppendHeader("Content-Disposition", bu.Header(id.Value));
            return new FileStreamResult(new MemoryStream(bu.Find(id.Value).File), bu.Find(id.Value).FileName);
         }

        //remove the specifc file from database
        [Authorize]
         public ActionResult Delete(int id)
         {
             bu.PostDeleteMethod(id);
             //return View();
             return RedirectToAction("Download");
         }

	}
}