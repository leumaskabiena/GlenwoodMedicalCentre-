

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Remoting.Contexts;
//using System.Web.

using DHTMLX.Scheduler;
using DHTMLX.Common;
using DHTMLX.Scheduler.Data;
using DHTMLX.Scheduler.Controls;
using DHTMLX.Helpers;
using DHTMLX.Scheduler.Settings;
using DHTMLX.Scheduler.Authentication;

using GlenwoodMed.BusinessLogic.Business;
using GlenwoodMed.Model.ViewModels;
using System.Globalization;
namespace GlenwoodMedicalCentre.Controllers
{
    [RequireHttps]
    public class CalendarController : Controller
    {
        private BookingBusiness b = new BookingBusiness();
        [Authorize]
        public ActionResult Index()
        {
            var scheduler = new DHXScheduler(this);
            var sched = new DHXBlockTime();
            //var t = b.TimeAvalOfDoc();
            scheduler.InitialDate = DateTime.Now;

            scheduler.LoadData = true;
            scheduler.Config.readonly_form = true;
            scheduler.EnableDataprocessor = true;
            scheduler.Config.select = true;
            //scheduler.Config.isReadonly = true;
            scheduler.Config.edit_on_create = true;
            scheduler.Skin = DHXScheduler.Skins.Flat;
            scheduler.Config.first_hour = 7;
            scheduler.Config.last_hour = 19;
            //scheduler.TimeSpans.Add(new DHXBlockTime()
            //{

            //    StartDate = Convert.ToDateTime(t.from),
            //    EndDate = Convert.ToDateTime(t.to)
            //});
            scheduler.TimeSpans.Add(new DHXBlockTime()
            {

                StartDate = new DateTime(2000, 8, 13),
                EndDate = DateTime.Now
            });
            scheduler.TimeSpans.Add(new DHXBlockTime()
            {
                Day = DayOfWeek.Sunday,

            });

            scheduler.BeforeInit.Add(string.Format("initResponsive({0})", scheduler.Name));

            return View(scheduler);
            #region MyRegion


            #endregion
        }
        public ContentResult Data()
        {
            var data = new SchedulerAjaxData(new BookingBusiness().displaySchedule());
            return (ContentResult)data;
        }
        public ActionResult ScheduleDate(int id, FormCollection actionValues)
        {
            string name = b.GetSaveBooking(id).FullName + "--" + b.GetSaveBooking(id).identification;
            var scheduler = new DHXScheduler(this);
            scheduler.InitialValues.Add("text", name);
            // scheduler.InitialValues.Add("color", "#FF0000");
            scheduler.InitialDate = DateTime.Now;
            ///scheduler.Templates.
            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;
            scheduler.Config.click_form_details = false;
            scheduler.Config.drag_create = false;
            scheduler.Config.drag_resize = false;
            scheduler.Config.drag_move = true;
            scheduler.Config.details_on_dblclick = false;
            scheduler.Config.details_on_create = false;
            scheduler.Config.event_duration = 20;
            scheduler.Config.collision_limit = 1;
            scheduler.Config.check_limits = true;
            scheduler.Config.limit_time_select = true;
            scheduler.Config.select = true;
            scheduler.Config.edit_on_create = true;
            scheduler.Config.first_hour = 7;
            scheduler.Config.last_hour = 19;
            scheduler.Config.show_quick_info = true;
            scheduler.Config.separate_short_events = true;
            scheduler.Config.readonly_form = true;

            scheduler.TimeSpans.Add(new DHXBlockTime()
            {

                StartDate = new DateTime(2000, 8, 13),
                EndDate = DateTime.Now
            });
            scheduler.TimeSpans.Add(new DHXBlockTime()
            {
                Day = DayOfWeek.Sunday,

            });
            System.Web.HttpContext.Current.Session["ide"] = id;

            return View(scheduler);


        }
        public ActionResult UpdateCalendar()
        {

            var scheduler = new DHXScheduler(this);

            // scheduler.InitialValues.Add("color", "#FF0000");
            scheduler.InitialDate = DateTime.Now;
            ///scheduler.Templates.
            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;
            scheduler.Config.click_form_details = false;
            scheduler.Config.drag_create = false;
            scheduler.Config.drag_resize = false;
            scheduler.Config.drag_move = true;
            scheduler.Config.details_on_dblclick = false;
            scheduler.Config.details_on_create = false;
            scheduler.Config.event_duration = 20;
            scheduler.Config.collision_limit = 1;
            scheduler.Config.check_limits = true;
            scheduler.Config.limit_time_select = true;
            scheduler.Config.select = false;
            scheduler.Config.edit_on_create = false;
            scheduler.Config.first_hour = 7;
            scheduler.Config.last_hour = 19;
            scheduler.Config.show_quick_info = true;
            scheduler.Config.separate_short_events = true;
            scheduler.Config.readonly_form = true;

            scheduler.TimeSpans.Add(new DHXBlockTime()
            {

                StartDate = new DateTime(2000, 8, 13),
                EndDate = DateTime.Now
            });
            scheduler.TimeSpans.Add(new DHXBlockTime()
            {
                Day = DayOfWeek.Sunday,

            });


            return View(scheduler);

        }

        public ActionResult Save(FormCollection actionValues)
        {
            var scheduler = new DHXScheduler(this);

            var action = new DataAction(actionValues);
            // scheduler.InitialValues.Add("text");
            try
            {
                var changedEvent = (Schedule)DHXEventsHelper.Bind(typeof(Schedule), actionValues);
                int d = Convert.ToInt32(System.Web.HttpContext.Current.Session["ide"]);
                var dat = new BookingBusiness();
                // changedEvent.text = dat.GetSaveBooking(d).FullName + "<br/>" + dat.GetSaveBooking(d).Physician;
                string name = dat.GetSaveBooking(d).FullName;

                switch (action.Type)
                {
                    case DataActionTypes.Insert:

                        dat.InsertSaveBooking(changedEvent, d);

                        break;
                    case DataActionTypes.Delete:

                        int num;
                        try
                        {
                            num = Convert.ToInt32(action.SourceId);
                        }
                        catch (Exception)
                        {
                            return RedirectToAction("Index", "Calendar");
                        }
                        dat.DeleteSavedBooking(num);
                        break;
                    default:// "update"     
                        var evt = b.displaySchedule().SingleOrDefault(ez => ez.id == action.SourceId);

                        DHXEventsHelper.Update(evt, changedEvent, new List<string>() { "id" });

                        //do update
                        b.UpdateSavedBooking(evt, changedEvent);
                        break;
                }

                action.TargetId = changedEvent.id;
            }
            catch
            {
                action.Type = DataActionTypes.Error;
            }
            return (ContentResult)new AjaxSaveResponse(action);
        }
    }
}
