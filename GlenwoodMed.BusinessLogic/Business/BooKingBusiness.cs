using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using GlenwoodMed.Data.Tables;
using System.Net.Mail;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class BookingBusiness : IBookingBusiness
    {
        /* frist sept in creating a booking for a patient*/
        // find out if it's a new or old patient

        #region Check if the patient exists in the database
        public List<PatientModel> GetAllPat(string pat)
        {
            using (var pt = new PatientRepository())
            {
                return pt.GetAll().Where(x => x.FullName.ToLower().Contains(pat.ToLower()) || x.Surname.ToLower().Contains(pat.ToLower())).Select(a => new PatientModel
                {
                    userId = a.PatientId,
                    FullName = a.FullName,
                    Surname = a.Surname,
                    Telephone = a.Telephone,
                    DOB = a.DOB,
                    Email = a.Email,
                    NationalId = a.NationalId
                }).ToList();
            }
        }
        public int PatientExist(string pat)
        {
            int num = 0;
            using (var pt = new PatientRepository())
            {
                try
                {
                    var patient = pt.GetAll().Find(x => x.NationalId == pat || x.PatientNo == pat);
                    if (patient.PatientId != 0)
                    {
                        num = patient.PatientId;
                    }
                }
                catch (Exception)
                {

                    num = 0;
                }
            }
            return num;
        }
        #endregion

        #region Retrive all information for the patient in the database
        public bookingPatient FindPatientDetails(int? id)
        {
            bookingPatient rm = new bookingPatient();

            using (var parepo = new PatientRepository())
            {
                if (id.HasValue && id != 0)
                {
                    Patient _patient = parepo.GetById(id.Value);
                    rm.FullName = _patient.FullName;
                    rm.Email = _patient.Email;
                    rm.Telephone = _patient.Telephone;
                    rm.identification = _patient.NationalId;
                    rm.PatientIdKey = id.Value;
                }
                return rm;
            }
        }
        #endregion
        public bool GetBookingDetails(string dat)
        {
            bool ans = false;
            //var pat = 
            using (var bookpro = new BookingRepository())
            {
                try
                {
                    var pat = bookpro.GetAll().FindLast(z => z.PatientID.Equals(dat));
                    DateTime date = Convert.ToDateTime(pat.Time_start);
                    DateTime date1 = Convert.ToDateTime(pat.Time_end);
                    int num1 = DateTime.Compare(date, DateTime.Now);
                    int num2 = DateTime.Compare(date1, DateTime.Now);

                    if (DateTime.Equals(date, DateTime.Now) && DateTime.Equals(date1, DateTime.Now))
                    {
                        ans = true;
                    }
                    //if (num1 < 0 || num2 < 0)
                    //{
                    //    ans = true;
                    //}
                }
                catch (Exception)
                {

                    ans = false;
                }
                return ans;
            }

        }
        public string DateOfBooking(string date)
        {
            using (var bookpro = new BookingRepository())
            {
                try
                {
                    return bookpro.GetAll().Last(x => x.PatientID == date && x.bookingStatus.Equals("Booked")).Time_start.Substring(0, 10);
                }
                catch (Exception)
                {

                    return DateTime.Now.ToString();
                }

            }
        }
        #region Save Slot for the patient
        public void SaveBooking(bookingPatient model)
        {
            using (var bookpro = new BookingRepository())
            {
                if (model.BookingId == 0)
                {
                    Booking _booking = new Booking
                    {
                        BookingId = model.BookingId,
                        PatientFullName = model.FullName,
                        PatientID = model.identification,
                        Email = model.Email,
                        Date = DateTime.Today.ToString(),
                        Telephone = model.Telephone,
                        Physician = model.Physician,
                        bookingStatus = "None",
                        PatientIdKey = model.PatientIdKey
                    };
                    bookpro.Insert(_booking);
                    System.Web.HttpContext.Current.Session["bookingId"] = _booking.BookingId;
                }
            }
        }
        #endregion

        public List<Schedule> BookingBeforeUpdate()
        {
            using (var boopro = new BookingRepository())
            {
                return boopro.GetAll().FindAll(xe => xe.bookingStatus.Equals("None")).Select(x => new Schedule
                {
                    id = x.BookingId,
                    text = x.PatientFullName,
                    start_date = x.Time_start,
                    end_date = x.Time_start
                }).ToList();
            }
        }

        #region return the booking's details for a patient who hasn't confirm
        public bookingPatient GetSaveBooking(int id)
        {
            bookingPatient bo = new bookingPatient();
            string nat = new PatientRepository().GetById(id).NationalId;
            using (var bookpro = new BookingRepository())
            {
                Booking _booking = bookpro.GetAll().Find(x => x.PatientID.Equals(nat));
                // bo.BookingId = _booking.BookingId;
                bo.FullName = _booking.PatientFullName;

                bo.identification = _booking.PatientID;
                bo.date = _booking.Date;
                bo.bookingStatus = _booking.bookingStatus;
                return bo;
            }
        }
        #endregion

        #region Update The status for the booking to "Booked" for a patient
        // public void InsertSaveBooking(int id,Schedule m)
        public void InsertBook(Schedule m)
        {
            using (var bok = new BookingRepository())
            {
                Booking b = new Booking();
                b.BookingId = m.id;
                b.PatientFullName = m.text;
                b.Time_start = m.start_date;
                b.Time_end = m.end_date;
                b.bookingStatus = "reservation";
                bok.Insert(b);
            }
        }
        public void InsertSaveBooking(Schedule m, int d)
        {
            string nat = new PatientRepository().GetById(d).NationalId;

            using (var bookpro = new BookingRepository())
            {
                Booking _b = bookpro.GetAll().Last(x => x.PatientID.Equals(nat));

                _b.Time_start = m.start_date;
                _b.Time_end = m.end_date;
                _b.bookingStatus = "Booked";
                bookpro.Update(_b);

            }
            var p = new PatientRepository().GetAll().Find(x => x.PatientId == d);

            using (var emailrepo = new EmailRepository())
            {
                List<MailAddress> l = new List<MailAddress>();
                MailMessage mail = new MailMessage();

                mail.To.Add(new MailAddress(p.Email));
                mail.From = new MailAddress("Admin@Glenwoodmedicalcenter.com");
                mail.CC.Add(new MailAddress("Admin@Glenwoodmedicalcenter.com"));
                mail.Bcc.Add(new MailAddress("Admin@Glenwoodmedicalcenter.com"));
                mail.Subject = "Appointment with the Doctor";
                string Body = "Dear " + p.FullName + " we are glad to inform you that your appointment to see the doctor has been schedule on the "
                                     + m.start_date.Substring(0, 10) + " from " + m.start_date.Substring(10) + " to " + m.end_date.Substring(10);
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                #region configurations is in the web.config
                // smtp.Host = "localhost";//"smtp.live.com"; 
                //// smtp.Host = "smtp.live.com";

                // smtp.Port = 25; //587;
                // // smtp.Port=587;

                #endregion


                smtp.Host = "smtp.sendgrid.net";
                smtp.Port = 2525;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("bigiayomide", "123adenike");// enter seders user name and password



                smtp.Send(mail);

                Email_services _email = new Email_services
                {
                    emailID = 0,
                    To = p.Email,
                    //Cc = "Admin@Glenwoodmedicalcenter.com",
                    //Bcc = "Admin@Glenwoodmedicalcenter.com",
                    Subject = "Appointment with the Doctor",
                    StaffName = "sam",
                    Body = Body
                };

                emailrepo.Create(_email);
            }

        }



        #endregion

        public void DeleteSavedBooking(int id)
        {

            using (var emailrepo = new EmailRepository())
            {
                var em = new BookingRepository().GetById(id);
                List<MailAddress> l = new List<MailAddress>();
                MailMessage mail = new MailMessage();

                mail.To.Add(new MailAddress(em.Email));
                mail.From = new MailAddress("Admin@Glenwoodmedicalcenter.com");
                //mail.CC.Add(new MailAddress("Admin@Glenwoodmedicalcenter.com"));
                //mail.Bcc.Add(new MailAddress("Admin@Glenwoodmedicalcenter.com"));
                mail.Subject = "Appointment with the Doctor";
                string Body = "Dear " + em.PatientFullName + "  your appointment to see the doctor  on the "
                                     + em.Time_start.Substring(0, 10) + " from " + em.Time_start.Substring(10) + " to " + em.Time_end.Substring(10) + " has been canceled";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                #region configurations is in the web.config
                //smtp.Host = "localhost";//"smtp.live.com"; 
                //// smtp.Host = "smtp.live.com";

                //smtp.Port = 25; //587;

                //// smtp.Port=587;

                #endregion


                smtp.Host = "smtp.sendgrid.net";
                smtp.Port = 2525;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("bigiayomide", "123adenike");// enter seders user name and password



                smtp.Send(mail);

                using (var bookpro = new BookingRepository())
                {
                    Booking _booking = bookpro.GetById(id);
                    bookpro.Delete(_booking);
                }
            }
        }

        //public void DeleteSavedBooking(int id)
        //{
        //    using (var bookpro = new BookingRepository())
        //    {
        //        Booking _booking = bookpro.GetById(id);
        //        bookpro.Delete(_booking);
        //    }
        //}
        public void UpdateSavedBooking(Schedule sc, Schedule x)
        {
            using (var bookpro = new BookingRepository())
            {

                Booking _booking = bookpro.GetById(sc.id);
                {
                    _booking.BookingId = sc.id;
                    _booking.PatientFullName = _booking.PatientFullName;
                    _booking.Time_start = x.start_date;
                    _booking.Time_end = x.end_date;


                    bookpro.Update(_booking);
                }
            }
            using (var emailrepo = new EmailRepository())
            {
                string em = new BookingRepository().GetById(sc.id).Email;
                List<MailAddress> l = new List<MailAddress>();
                MailMessage mail = new MailMessage();

                mail.To.Add(new MailAddress(em));
                mail.From = new MailAddress("Admin@Glenwoodmedicalcenter.com");
                //mail.CC.Add(new MailAddress("Admin@Glenwoodmedicalcenter.com"));
                //mail.Bcc.Add(new MailAddress("Admin@Glenwoodmedicalcenter.com"));
                mail.Subject = "Appointment with the Doctor";
                string Body = "Dear " + sc.text + " we are glad to inform you that your appointment to see the doctor has been Re-schedule on the "
                                     + x.start_date.Substring(0, 10) + " from " + x.start_date.Substring(10) + " to " + x.end_date.Substring(10);
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                #region configurations is in the web.config
                //smtp.Host = "localhost";//"smtp.live.com"; 
                //// smtp.Host = "smtp.live.com";

                //smtp.Port = 25; //587;
                //// smtp.Port=587;

                #endregion


                smtp.Host = "smtp.sendgrid.net";
                smtp.Port = 2525;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("bigiayomide", "123adenike");// enter seders user name and password



                smtp.Send(mail);


            }
        }

        #region Display All the Reservation booking for a patient
        public List<Schedule> displaySchedule()
        {
            using (var boopro = new BookingRepository())
            {
                return boopro.GetAll().FindAll(xe => xe.bookingStatus.Equals("Booked")).Select(x => new Schedule
                {
                    id = x.BookingId,
                    text = x.PatientFullName,
                    start_date = x.Time_start,
                    end_date = x.Time_start
                }).ToList();
            }
        }
        #endregion


        // Display the information of the patient
        #region Create a resquest booking Booking

        public void resquestBooking(bookingPatient model)
        {
            using (var bookpro = new BookingRepository())
            {
                if (model.BookingId == 0)
                {
                    Booking _booking = new Booking
                    {
                        BookingId = model.BookingId,
                        PatientFullName = model.FullName,
                        PatientID = model.identification,
                        Email = model.Email,
                        Telephone = model.Telephone,
                        Physician = model.Physician,
                        Date = model.date

                    };
                    bookpro.Insert(_booking);
                }
            }
        }

        #endregion




        #region view all the resquest booking
        public List<bookingPatient> GetAllRequest()
        {
            using (var boopro = new BookingRepository())
            {
                return boopro.GetAll().FindAll(x => x.bookingStatus.Equals("reservation")).Select(y => new bookingPatient()
                {
                    BookingId = y.BookingId,
                    FullName = y.PatientFullName,
                    identification = y.PatientID,
                    Email = y.Email,
                    Telephone = y.Telephone,
                    Physician = y.Physician,
                    date = y.Date
                }
                    ).ToList();
            }
        }
        public void UpdateResquestBooking(int id)
        {
            using (var boopro = new BookingRepository())
            {
                var bk = boopro.GetById(id);
                bk.bookingStatus = "booked";
                boopro.Update(bk);
            }

        }
        #endregion

        #region view all the resquest booking
        public List<bookingPatient> GetAllBookings()
        {
            var pro = new PatientRepository();

            using (var boopro = new BookingRepository())
            {
                return boopro.GetAll().Select(y => new bookingPatient()
                {
                    BookingId = y.BookingId,
                    FullName = y.PatientFullName,
                    identification = y.PatientID,
                    Email = y.Email,
                    Telephone = y.Telephone,
                    Physician = y.Physician,
                    date = y.Date,
                    start_date = y.Time_start,
                    end_date = y.Time_end,
                    time = y.Time,
                    Status = y.Status,
                    PatientIdKey = y.PatientIdKey,
                    resultFile = pro.GetById(y.PatientIdKey).File,
                    FileName = pro.GetById(y.PatientIdKey).FileName,
                    FileType = pro.GetById(y.PatientIdKey).FileType,
                    notification = y.notificationStatus,
                    bookingStatus = y.bookingStatus
                }).ToList();
            }
        }
        #endregion







        #region Find a requestBooking
        public bookingPatient GetBooking(int? id)
        {
            bookingPatient bo = new bookingPatient();
            using (var bookpro = new BookingRepository())
            {
                Booking _booking = bookpro.GetById(id.Value);

                bo.BookingId = _booking.BookingId;
                bo.FullName = _booking.PatientFullName;
                bo.Email = _booking.Email;
                bo.date = _booking.Date;

                bo.time = _booking.Time;
                bo.start_date = _booking.Time_start;
                bo.end_date = _booking.Time_end;
                return bo;
            }
        }
        #endregion


        #region Find a patient in the database
        public Patient GetOne(int PatientId)
        {
            var bookpro = new PatientRepository();

            return bookpro.GetById(PatientId);
        }
        #endregion

        #region Create a booking for the patient
        public void booking(bookingPatient model, int PatientId)
        {
            using (var bookpro = new BookingRepository())
            {
                if (model.BookingId == 0)
                {
                    Booking _booking = new Booking
                    {
                        BookingId = model.BookingId,
                        PatientFullName = model.FullName,
                        PatientID = model.identification,
                        Email = model.Email,
                        Telephone = model.Telephone,
                        Physician = model.Physician,
                        Date = model.date,
                        Status = 0,
                        PatientIdKey = PatientId
                    };
                    bookpro.Insert(_booking);
                    System.Web.HttpContext.Current.Session["bookingId"] = _booking.BookingId;
                }
            }
        }

        #endregion



        #region View All the Booking on the calendar
        public List<Schedule> GetAllSchedule()
        {
            using (var boopro = new BookingRepository())
            {
                return boopro.GetAll().FindAll(Xe => Xe.Time != null).Select(x => new Schedule
                {
                    id = x.BookingId,
                    text = x.PatientFullName + "                         <br/>ID: " + x.PatientID + "<br/>Reson: " + x.Physician + "<br/>Time: " + x.Time + "<br/>Email: " + x.Email + "<br/>Telephone: " + x.Telephone,

                    start_date = x.Date.Substring(0, 2) + "," + x.Date.Substring(3, 2) + "," + x.Date.Substring(6, 4) + "," + x.Time_start,
                    end_date = x.Date.Substring(0, 2) + "," + x.Date.Substring(3, 2) + "," + x.Date.Substring(6, 4) + "," + x.Time_end
                }

                    ).ToList();
            }
        }
        #endregion

        #region Count Bookings...
        public int CountMethod()
        {
            int count = 0;
            var boopro = new BookingRepository();

            var allpatients = boopro.GetAll().Where(x => x.Status == 0 && Convert.ToDateTime(x.Time_start).Date.Day == DateTime.Now.Day
                                                                        && Convert.ToDateTime(x.Time_start).Date.Month == DateTime.Now.Month
                                                                        && Convert.ToDateTime(x.Time_start).Date.Year == DateTime.Now.Year).ToList();

            //var allpatients = boopro.GetAll().Where(x => x.Status == 0 && Convert.ToDateTime(x.Time_start).Date.Day == DateTime.Now.Date.Day).ToList();

            foreach (GlenwoodMed.Data.Tables.Booking pa in allpatients)
            {
                count++;
            }

            return count;
        }
        #endregion

        #region PostEditBooking
        public void EndConsultaion(int bookingId)
        {
            using (var bookpro = new BookingRepository())
            {

                Booking _booking = bookpro.GetById(bookingId);

                _booking.Status = 1;
                bookpro.Update(_booking);
            }
        }
        #endregion

        #region CountConsulted
        public int Consulted()
        {
            int count = 0;
            using (var bookpro = new BookingRepository())
            {
                List<Booking> books = new List<Booking>();
                books = bookpro.GetAll().Where(x => x.Status == 1 && Convert.ToDateTime(x.Time_start).Date.Day == DateTime.Now.Day
                                                                        && Convert.ToDateTime(x.Time_start).Date.Month == DateTime.Now.Month
                                                                        && Convert.ToDateTime(x.Time_start).Date.Year == DateTime.Now.Year).ToList();

                foreach (var i in books)
                {
                    count++;
                }
                return count;
            }
        }
        #endregion

        #region CountNotConsulted
        public int NotConsulted()
        {
            int count = 0;
            using (var bookpro = new BookingRepository())
            {
                List<Booking> books = new List<Booking>();
                books = bookpro.GetAll().Where(x => x.Status == 0 && Convert.ToDateTime(x.Time_start).Date.Day == DateTime.Now.Day
                                                                        && Convert.ToDateTime(x.Time_start).Date.Month == DateTime.Now.Month
                                                                        && Convert.ToDateTime(x.Time_start).Date.Year == DateTime.Now.Year).ToList();

                foreach (Booking i in books)
                {
                    count++;
                }
                return count;
            }
        }
        #endregion
        #region Display()
        public List<Schedule> display()
        {
            using (var boopro = new BookingRepository())
            {
                List<Booking> lst = boopro.GetAll().ToList();
                return boopro.GetAll().Select(x => new Schedule
                {
                    id = x.BookingId,
                    text = "Booked",
                    start_date = x.Time_start,
                    end_date = x.Time_start
                }).ToList();
            }
        }
        public List<Schedule> displayT(string pat)
        {
            using (var boopro = new BookingRepository())
            {
                string st = "Booked";
                List<Booking> lst = boopro.GetAll().ToList();
                Schedule t = new Schedule();
                List<Schedule> l = new List<Schedule>();
                foreach (Booking x in lst)
                {
                    if (x.Email.Equals(pat))
                    {
                        st = x.PatientFullName;
                    }

                    t.id = x.BookingId;
                    t.text = st;
                    t.start_date = x.Time_start;
                    t.end_date = x.Time_start;
                    l.Add(t);
                }
                return l;
            }
        }
        #endregion


        public void saveDoctorAv(AvailDoctor m)
        {
            DateTime form = Convert.ToDateTime(m.from);
            DateTime to = form.AddDays(Convert.ToDouble(m.num));

            string end_date = to.ToString().Substring(8, 2) + "/" + to.ToString().Substring(5, 2) + "/" + to.ToString().Substring(0, 4);
            using (var bookpro = new BookingRepository())
            {

                Booking _b = new Booking();
                _b.BookingId = m.id;
                _b.PatientFullName = "Doctor";
                _b.PatientIdKey = 0;
                _b.notificationStatus = false;
                _b.PatientID = "1547899655";
                _b.Telephone = "0781787520";
                _b.Time_start = m.from;
                _b.Time_end = end_date;
                _b.bookingStatus = "Doctor";
                bookpro.Insert(_b);
            }
        }
        public AvailDoctor TimeAvalOfDoc()
        {
            using (var bookpro = new BookingRepository())
            {
                AvailDoctor av = new AvailDoctor();
                try
                {
                    var z = bookpro.GetAll().Last(x => x.bookingStatus.Equals("Booked"));
                    av.id = z.BookingId;
                    av.from = z.Time_start;
                    av.to = z.Time_end;
                }
                catch
                {
                    //  var z = bookpro.GetAll().Last(x => x.bookingStatus.Equals("Booked"));
                    av.id = 1;
                    av.from = "2000, 8, 13";
                    av.to = "2000, 9, 13";
                }
                // var z = bookpro.GetAll().Last(x => x.bookingStatus.Equals("Booked"));


                return av;
            }
        }
    }
}
