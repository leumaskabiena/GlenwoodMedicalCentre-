using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class NotificationBusiness : INotificationBusiness
    {
        private DataContext db = new DataContext();
        private NotificationModel nm = new NotificationModel();
        private const string HtmlEmailHeader = "<html><head><title>GlenwoodMedicalCentre</title></head><body style='font-family:arial; font-size:14px;'>";
        private const string HtmlEmailFooter = "</body></html>";

        //public void sendSMS()
        //{

        //}

        public void sendNotification()
        {
            //PatientBusiness pb = new PatientBusiness();
            //BookingBusiness bb = new BookingBusiness();
            Booking b = new Booking();
            Notification n = new Notification();
            bookingPatient bp = new bookingPatient();
            Email_serviceViewModel es = new Email_serviceViewModel();
            Email_serviceBusiness esb = new Email_serviceBusiness();

            //var booknotif= bb.GetAllBookings();
            var brepo = new BookingRepository();

            foreach (Booking p in brepo.GetAll())
            {

                int day = Convert.ToDateTime(p.Time_start).Date.Day;
                int month = Convert.ToDateTime(p.Time_start).Date.Month;
                int year = Convert.ToDateTime(p.Time_start).Date.Year;
                if (p.notificationStatus != true)
                {
                    if (month == DateTime.Now.Month && year == DateTime.Now.Year)
                    {
                        if (day - 1 == Convert.ToInt32(DateTime.Now.Day))
                        {

                            es.To = p.Email;
                            es.Subject = "Reminder";
                            es.Body = "Good day dear " + p.PatientFullName + "<br/>" + "We want to remind you that you have an appointement tomorrow at " + p.Time + " at Glenwood Medical Centre";
                            esb.createemail(es);
                        }
                    }
                    p.notificationStatus = true;
                    brepo.Update(p);
                }
            }
        }
    }
}
