using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;
using GlenwoodMed.Data.Tables;
using System.IO;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class TestResultController : Controller
    {
        TestResultBusiness dbo = new TestResultBusiness();

        //
        // GET: /TestResult/
        public ActionResult Index(int PatientId, int? page, int pageSize = 5)
        {
            var model = new TestResult()
            {
                PatientName = dbo.Patients(PatientId),
                PatientId = PatientId
            };
            return View(model);
            //var cn = dbo.GetAll().OrderBy(x => x.PatientName).ToList();
            //if (Request.HttpMethod != "GET")
            //{
            //    page = 1;
            //}
            //int pageNumber = (page ?? 1);
            //List<TestResult> pm = cn;
            //PagedList<TestResult> model = new PagedList<TestResult>(pm, pageNumber, pageSize);
            //return View(model);
        }
        public ActionResult XRayDownload(int? id)
        {
            Response.AppendHeader("Content-Disposition", dbo.Header(id.Value));
            return new FileStreamResult(new MemoryStream(dbo.Find(id.Value).File), dbo.Find(id.Value).FileName);
        }
        [HttpPost]
        public ActionResult Index(TestResult model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            dbo.InsertMethod(model, model.PatientId);
            return RedirectToAction("AllFiles", "TestResult", new { PatientId = model.PatientId });
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
            //#endregion
            //bu.InsertMethod(model, PatientI);
            //return Content("File successfull Uploaded");
            // return RedirectToAction("Download", "UploadFile");
            //int PatientI = Convert.ToInt32(System.Web.HttpContext.Current.Session["Id"]);
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            //dbo.CreateMethod(model, PatientI);
            //return RedirectToAction("Index", "TestResult");
        }

        public ActionResult AllFiles(int? PatientId, int? page, int pageSize = 5)
        {
            var cn = dbo.GetAllFiles(PatientId.Value).OrderBy(x => x.PatientName).ToList();
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageNumber = (page ?? 1);
            List<TestResult> pm = cn;
            PagedList<TestResult> model = new PagedList<TestResult>(pm, pageNumber, pageSize);
            return View(model);
            //return View(dbo.GetAllFiles(PatientId).OrderBy(x => x.PatientName).ToList());
        }

        public ActionResult AddTestResult(int? page, int pageSize = 5, string testpar = "")
        {
            var dbo = new PatientBusiness();

            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);
            List<PatientModel> pm = dbo.GetAllPatients().Where(x => x.FullName.ToLower().Contains(testpar.ToLower()) ||
                                                                x.Surname.ToLower().Contains(testpar.ToLower()) ||
                                                                x.NationalId.ToLower().Contains(testpar.ToLower()) ||
                                                                testpar == null).ToList();
            PagedList<PatientModel> model = new PagedList<PatientModel>(pm, pageNumber, pageSize);
            return View("AddTestResult", pm.ToPagedList(pageNumber, pageSize));
        }


        //public ActionResult Details(int? id)
        //{
        //    var dbo = new TestResultBusiness();
        //    return PartialView(dbo.DetailsMethod(id));
        //}

        //public ActionResult Create(int PatientId)
        //{
        //        System.Web.HttpContext.Current.Session["PatientId"] = PatientId;
        //        var model = new TestResult()
        //        {

        //            PatientName = dbo.Patients(PatientId)

        //        };
        //        return View(model);
        //}
        public ActionResult Main()
        {
            var model = new TestResult();
            return PartialView(model);
        }
        //[HttpPost]
        //public ActionResult Create(TestResult model)
        //{
        //    int PatientI = Convert.ToInt32(System.Web.HttpContext.Current.Session["Id"]);
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //        dbo.CreateMethod(model, PatientI);
        //        return RedirectToAction("Index", "TestResult");
        //}
        //public ActionResult Update(int id)
        //{
        //    var dbo = new TestResultBusiness();
        //    return View(dbo.GetReviewMethod(id));
        //}
        //[HttpPost]
        //public ActionResult Update(int id, TestResult model)
        //{
        //    try
        //    {
        //        var dbo = new TestResultBusiness();

        //        dbo.PostReviewMethod(model);
        //        TempData["msg"] = "Data has been successfully Updated";
        //        return RedirectToAction("Index", new { Id = id });
        //    }
        //    catch
        //    {

        //        return View();
        //    }
        //}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            dbo.PostDeleteMethod(id);
            return RedirectToAction("AllFiles");
        }
    }
}
