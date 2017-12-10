using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class SMSBusiness : ISMSBusiness
    {
        Booking b = new Booking();
        bookingPatient bp = new bookingPatient();



        //var booknotif= bb.GetAllBookings();


        private string s;
        private string s_2;

        public SMSBusiness()
        {
            s = String.Empty;
            s_2 = String.Empty;
        }
        public SMSBusiness(string s, string s_2)
        {

            this.s = s;
            this.s_2 = s_2;
        }
        public string MyString { get; set; }
        private string username;

        public string UserName
        {
            get { return username = "gracedivinediams@gmail.com"; }
            set { username = "gracedivinediams@gmail.com"; }
        }
        private string password;

        public string Password
        {
            get { return password = "Diva007"; }
            set { password = "Diva007"; }
        }
        public string Message { get; set; }
        public string Number { get; set; }
        public string MailError { get; set; }

        public string readHtmlPage(string url)
        {
            WebResponse objResponse;
            WebRequest objRequest;

            string result;
            try
            {
                objRequest = System.Net.HttpWebRequest.Create(url);
                objResponse = objRequest.GetResponse();
                StreamReader sr = new StreamReader(objResponse.GetResponseStream());
                result = sr.ReadToEnd();
                sr.Close();
                return result;
            }
            catch (Exception er)
            {
                string s = er.Message;
                return s;
            }
        }

        public void sendSMS()
        {
            var brepo = new BookingRepository();

            foreach (Booking p in brepo.GetAll())
            {
                int day = Convert.ToDateTime(p.Time_start).Date.Day;
                int month = Convert.ToDateTime(p.Time_start).Date.Month;
                int year = Convert.ToDateTime(p.Time_start).Date.Year;

                if(p.notificationStatus != true)
                {
                    if (month == DateTime.Now.Month && year == DateTime.Now.Year)
                    {
                        if (day - 1 == Convert.ToInt32(DateTime.Now.Day))
                        //if ((DateTime.Now.Day + 1)  == Convert.ToInt32(day))
                        {
                            string msgz = "Good day dear " + p.PatientFullName + " We want to remind you that you have an appointement tomorrow at " + p.Time + " at Glenwood Medical Centre";

                            string datesent = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                            MyString = "http://www.winsms.net/api/batchmessage.asp?User=";
                            MyString = MyString + UserName + "&Password=" + Password + "&Delivery=No";
                            MyString = MyString + "&Message=" + msgz + "&Numbers=" + p.Telephone + ";";
                            MailError = (readHtmlPage(MyString));
                            MailError = ("Your message has been sent");


                        }
                    }
                    p.notificationStatus = true;
                    brepo.Update(p);
                }

                
            }
        }
    }
}
