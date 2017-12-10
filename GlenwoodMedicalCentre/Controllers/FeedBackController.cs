using GlenwoodMed.BusinessLogic;
using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Data;
using GlenwoodMed.Model;
using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class FeedBackController:Controller
    {
        [Authorize(Roles="Patient")]
        public ActionResult Index()
        {
            var model = new FeedBackBusiness();
            return View(model.GetAll());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult PostRating(int rating)
        {
            string rate = "";
            switch (rating)
            {
                case 1:
                    rate = "poor";
                    break;
                case 2:
                    rate = "bad";
                    break;
                case 3:
                    rate = "Great";
                    break;
                case 4:
                    rate = "Excellent";
                    break;
                case 5:
                    rate = "Excellent";
                    break;

            }
            System.Web.HttpContext.Current.Session["rate"] = rating.ToString();
            return Json("You rated " + rating.ToString() + " as " + rate.ToString() + " star(s)");
        }

        [Authorize(Roles = "Patient")]
        public ActionResult CreateFeedBack()
        {
            var dbo = new FeedBackBusiness();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]
        public ActionResult CreateFeedBack(FeedBackViewModel model)
        {
            string feedback = "";
            try
            {
                

                var dbo = new FeedBackBusiness();
                feedback = System.Web.HttpContext.Current.Session["rate"].ToString();
                dbo.CreateMethod(model, feedback);
                //dbo.sSave();
                foreach (FeedBackViewModel dg in dbo.GetAll())
                {
                    ViewBag.Name = dg.Name;
                }

                TempData["message"] = "Data has been successfully submited";
                return RedirectToAction("Index", "PatientView");
            }
            catch (DataException)
            {

                return View(model);
            }
        }
        public ActionResult Details(int? id)
        {
            var dbo = new FeedBackBusiness();
            return View(dbo.DetailsMethod(id));
        }
        public ActionResult Delete(int id)
        {

            var dbo = new FeedBackBusiness();
            return View(dbo.GetDeleteMethod(id));
        }

        //[HttpPost, ActionName("Delete")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            try
            {
                var dbo = new FeedBackBusiness();
                dbo.PostDeleteMethod(id);
                

                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }
        
    }
}