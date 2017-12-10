#region MyRegion
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using DHTMLX.Scheduler;
//using DHTMLX.Common;
//using DHTMLX.Scheduler.Data;
//using DHTMLX.Scheduler.Controls;
//using DHTMLX.Helpers;
//using DHTMLX.Scheduler.Settings;
//using DHTMLX.Scheduler.Authentication;
//using System.Web.Mvc;

//using GlenwoodMed.BusinessLogic.Business;
//using GlenwoodMed.Model.ViewModels;
//using System.Globalization;
//namespace GlenwoodMedicalCentre.Controllers
//{
//    public class DoctorAvailController : Controller
//    {
//        private BookingBusiness b = new BookingBusiness();
//        public ActionResult Index()
//        {
//            var scheduler = new DHXScheduler(this);
//            var sched = new DHXBlockTime();

//            scheduler.InitialDate = DateTime.Now;

//            scheduler.LoadData = true;
//            scheduler.EnableDataprocessor = true;
//            scheduler.TimeSpans.Add(new DHXBlockTime()
//            {


//            });



//            scheduler.Config.readonly_form = true;
//            scheduler.BeforeInit.Add(string.Format("initResponsive({0})", scheduler.Name));

//            return View(scheduler);
//            #region MyRegion
//            //  var bctime = new DHXBlockTime();

//            //  scheduler.InitialDate = DateTime.Now;
//            //  scheduler.InitialView = "day";
//            //  scheduler.LoadData = true;
//            //  scheduler.Config.time_step = 2;
//            //  scheduler.EnableDataprocessor = true;
//            // // bctime.
//            //  scheduler.Config.click_form_details = false;
//            //  scheduler.Config.readonly_form = true;
//            //  scheduler.Config.details_on_dblclick = false;
//            //  scheduler.Config.details_on_create = false;
//            //  scheduler.Config.edit_on_create = false;
//            //  scheduler.Config.drag_create = true;
//            ////  scheduler.XY.scale_height = 20;
//            //  scheduler.Config.limit_view = true;
//            //  scheduler.Config.cascade_event_display = true;
//            //  scheduler.Config.select = false;
//            //  scheduler.Config.show_quick_info = true;
//            //  scheduler.Config.separate_short_events = true;
//            //  scheduler.Config.collision_limit=1;
//            //  //scheduler.Config.bl

//            //  var mr = new SchedulerTimeSpanMarker();
//            //  mr.Mark(DateTime.Today, new DateTime(2015, 09, 09));


//            //  scheduler.Config.time_step = 20;




//            //  scheduler.BeforeInit.Add(string.Format("initResponsive({0})", scheduler.Name));

//            #endregion
//        }
//        public ContentResult Data()
//        {
//            var data = new SchedulerAjaxData(new BookingBusiness().displaySchedule());
//            return (ContentResult)data;
//        }
//        public ActionResult ScheduleDate(int id, FormCollection actionValues)
//        {
//            string name = b.GetSaveBooking(id).FullName + "--" + b.GetSaveBooking(id).identification;
//            var scheduler = new DHXScheduler(this);
//            scheduler.InitialValues.Add("text", name);
//            scheduler.InitialValues.Add("color", "#BBFF98");
//            scheduler.InitialDate = DateTime.Now;

//            scheduler.LoadData = true;
//            scheduler.EnableDataprocessor = true;
//            scheduler.Config.click_form_details = false;
//            scheduler.Config.drag_create = false;
//            scheduler.Config.drag_resize = false;
//            scheduler.Config.drag_move = true;
//            scheduler.Config.details_on_dblclick = false;
//            scheduler.Config.details_on_create = false;
//            scheduler.Config.event_duration = 20;
//            scheduler.Config.collision_limit = 1;
//            scheduler.Config.check_limits = true;
//            scheduler.Config.limit_time_select = true;
//            scheduler.Config.select = false;
//            scheduler.Config.edit_on_create = false;
//            scheduler.Config.first_hour = 7;
//            scheduler.Config.last_hour = 19;
//            scheduler.Config.show_quick_info = true;
//            scheduler.Config.separate_short_events = true;
//            scheduler.Config.readonly_form = true;

//            scheduler.TimeSpans.Add(new DHXBlockTime()
//            {

//                StartDate = new DateTime(2000, 8, 13),
//                EndDate = DateTime.Now
//            });
//            scheduler.TimeSpans.Add(new DHXBlockTime()
//            {
//                Day = DayOfWeek.Sunday,

//            });
//            System.Web.HttpContext.Current.Session["ide"] = id;

//            return View(scheduler);


//        }
//        public ActionResult DoctorTime()
//        {

//            var scheduler = new DHXScheduler(this);

//            var bo = b.displaySchedule();
//            scheduler.Templates.map_text = "bookingStatus";
//            foreach (var x in bo)
//            {
//                // scheduler.InitialValues.Add("text", "Booked");
//                scheduler.TimeSpans.Add(new DHXBlockTime()
//                {
//                    StartDate = Convert.ToDateTime(x.start_date),
//                    EndDate = Convert.ToDateTime(x.end_date)
//                });
//            }
//            scheduler.LoadData = true;
//            scheduler.EnableDataprocessor = true;
//            scheduler.Config.click_form_details = false;
//            scheduler.Config.drag_create = false;
//            scheduler.Config.drag_resize = false;
//            scheduler.Config.drag_move = true;
//            scheduler.Config.details_on_dblclick = false;
//            scheduler.Config.details_on_create = false;
//            scheduler.Config.event_duration = 20;
//            scheduler.Config.collision_limit = 1;
//            scheduler.Config.check_limits = true;
//            scheduler.Config.limit_time_select = true;
//            scheduler.Config.select = false;
//            scheduler.Config.edit_on_create = false;
//            scheduler.Config.first_hour = 7;
//            scheduler.Config.last_hour = 19;
//            scheduler.Config.show_quick_info = true;
//            scheduler.Config.separate_short_events = true;
//            scheduler.Config.readonly_form = true;



//            scheduler.BeforeInit.Add(string.Format("initResponsive({0})", scheduler.Name));
//            return View(scheduler);
//        }
//        public ActionResult Save(FormCollection actionValues)
//        {



//            var scheduler = new DHXScheduler(this);

//            var action = new DataAction(actionValues);
//            // scheduler.InitialValues.Add("text");
//            try
//            {
//                var changedEvent = (Schedule)DHXEventsHelper.Bind(typeof(Schedule), actionValues);
//                int d = Convert.ToInt32(System.Web.HttpContext.Current.Session["ide"]);
//                var dat = new BookingBusiness();
//                // changedEvent.text = dat.GetSaveBooking(d).FullName + "<br/>" + dat.GetSaveBooking(d).Physician;
//                string name = dat.GetSaveBooking(d).FullName;

//                switch (action.Type)
//                {
//                    case DataActionTypes.Insert:

//                        dat.InsertSaveBooking(changedEvent, d);

//                        break;
//                    case DataActionTypes.Delete:

//                        int num;
//                        try
//                        {
//                            num = Convert.ToInt32(action.SourceId);
//                        }
//                        catch (Exception)
//                        {
//                            return RedirectToAction("Index", "Calendar");
//                        }
//                        dat.DeleteSavedBooking(num);
//                        break;
//                    default:// "update"     
//                        var evt = b.displaySchedule().SingleOrDefault(ez => ez.id == action.SourceId);

//                        DHXEventsHelper.Update(evt, changedEvent, new List<string>() { "id" });

//                        //do update
//                        b.UpdateSavedBooking(evt, changedEvent);
//                        break;
//                }

//                action.TargetId = changedEvent.id;
//            }
//            catch
//            {
//                action.Type = DataActionTypes.Error;
//            }
//            return (ContentResult)new AjaxSaveResponse(action);
//        }



//    }

//} 
#endregion

#region MyRegion
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;


//using DHTMLX.Scheduler;
//using DHTMLX.Common;
//using DHTMLX.Scheduler.Data;
//using DHTMLX.Scheduler.Controls;

//using GlenwoodMedicalCentre.Models;
//namespace GlenwoodMedicalCentre.Controllers
//{
//    public class CalendarController : Controller
//    {
//        public ActionResult Index()
//        {
//            //Being initialized in that way, scheduler will use CalendarController.Data as a the datasource and CalendarController.Save to process changes
//            var scheduler = new DHXScheduler(this);


//            scheduler.InitialDate = new DateTime(2012, 09, 03);

//            scheduler.LoadData = true;
//            scheduler.EnableDataprocessor = true;

//            //
//            scheduler.BeforeInit.Add(string.Format("initResponsive({0})", scheduler.Name));

//            return View(scheduler);
//        }

//        public ContentResult Data()
//        {
//            var data = new SchedulerAjaxData(
//                    new List<CalendarEvent>{ 
//                        new CalendarEvent{
//                            id = 1, 
//                            text = "Sample Event", 
//                            start_date = new DateTime(2012, 09, 03, 6, 00, 00), 
//                            end_date = new DateTime(2012, 09, 03, 8, 00, 00)
//                        },
//                        new CalendarEvent{
//                            id = 2, 
//                            text = "New Event", 
//                            start_date = new DateTime(2012, 09, 05, 9, 00, 00), 
//                            end_date = new DateTime(2012, 09, 05, 12, 00, 00)
//                        },
//                        new CalendarEvent{
//                            id = 3, 
//                            text = "Multiday Event", 
//                            start_date = new DateTime(2012, 09, 03, 10, 00, 00), 
//                            end_date = new DateTime(2012, 09, 10, 12, 00, 00)
//                        }
//                    }
//                );
//            return (ContentResult)data;
//        }

//        public ContentResult Save(int? id, FormCollection actionValues)
//        {
//            var action = new DataAction(actionValues);

//            try
//            {
//                var changedEvent = (CalendarEvent)DHXEventsHelper.Bind(typeof(CalendarEvent), actionValues);



//                switch (action.Type)
//                {
//                    case DataActionTypes.Insert:
//                        //do insert
//                        action.TargetId = changedEvent.id;//assign postoperational id
//                        break;
//                    case DataActionTypes.Delete:
//                        //do delete
//                        break;
//                    default:// "update"                          
//                        //do update
//                        break;
//                }
//            }
//            catch
//            {
//                action.Type = DataActionTypes.Error;
//            }
//            return (ContentResult)new AjaxSaveResponse(action);
//        }
//    }
//}


#endregion

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
    public class DoctorAvailController : Controller
    {
        private BookingBusiness b = new BookingBusiness();
        public ActionResult Index()
        {
            var scheduler = new DHXScheduler(this);
            var sched = new DHXBlockTime();

            scheduler.LoadData = true;
            scheduler.InitialValues.Add("text", "Amisi");
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
            scheduler.Config.click_form_details = false;
            scheduler.Config.drag_move = false;
            scheduler.Config.isReadonly = true;
            var t = b.TimeAvalOfDoc();
            scheduler.TimeSpans.Add(new DHXBlockTime()
            {

                StartDate = Convert.ToDateTime(t.from),
                EndDate = Convert.ToDateTime(t.to)
            });
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
        public ContentResult Data()
        {
            string u = User.Identity.Name;
            var data = new SchedulerAjaxData(new BookingBusiness().displayT(u));
            return (ContentResult)data;
        }


        public ActionResult Save(FormCollection actionValues)
        {



            var scheduler = new DHXScheduler(this);

            var action = new DataAction(actionValues);
            // scheduler.InitialValues.Add("text");
            try
            {
                var changedEvent = (Schedule)DHXEventsHelper.Bind(typeof(Schedule), actionValues);


                switch (action.Type)
                {
                    case DataActionTypes.Insert:

                        b.InsertBook(changedEvent);

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
                        b.DeleteSavedBooking(num);
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