using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections;
using System.Data.SqlClient;
using System.IO;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class Email_serviceBusiness : IEmail_serviceBusiness
    {
        private DataContext db = new DataContext();
        private Email_serviceViewModel ee = new Email_serviceViewModel();
        private const string HtmlEmailHeader = "<html><head><title>GlenwoodMedicalCentre</title></head><body style='font-family:arial; font-size:14px;'>";
        private const string HtmlEmailFooter = "</body></html>";

        public List<Email_serviceViewModel> GetallEmail()
        {
            using(var clinicrepo=new EmailRepository())
            {
                return clinicrepo.GetAllEmail().Select(x => new Email_serviceViewModel()
                {
                    Body = x.Body,
                    Cc = x.Cc,
                    Subject=x.Subject,
                    To=x.To,
                    Bcc=x.Bcc,
                    StaffName=x.StaffName,
                    emailID=x.emailID,
                }).ToList();
            }
        }

        public List<MailAddress> to { get; set; }

        public void createemail(Email_serviceViewModel emails)//, HttpPostedFileBase fileUploader)
        {
            PatientBusiness dbl = new PatientBusiness();
            using (var emailrepo = new EmailRepository())
            {
                List<MailAddress> l = new List<MailAddress>();
                MailMessage mail = new MailMessage();


                if (emails.To == null)
                {
                    foreach (Patient f in dbl.GetPatients())//for each friend
                    {
                        //get the email address and convert to MailAddress
                        l.Add(new MailAddress(f.Email));//add to the list of receivers
                    }

                    to = l;

                    foreach (MailAddress ma in to)//get each MailAddress in the list
                    {
                        mail.To.Add(ma); //use to set the to list
                        Email_services _email = new Email_services
                        {
                            emailID = emails.emailID,
                            To = ma.ToString(),
                            Cc = emails.Cc,
                            Bcc = emails.Bcc,
                            Subject = emails.Subject,
                            StaffName = emails.StaffName,
                            Body = emails.Body
                        };

                        emailrepo.Create(_email);
                    }



                    //mail.To.Add(l);
                }
                
                else
                {
                    string[] ToMuliId = emails.To.Split(',');
                    foreach (string ToEMailId in ToMuliId)
                    {
                        mail.To.Add(new MailAddress(ToEMailId)); //adding multiple TO Email Id
                    }
                }

                /*mail.To.Add(emails.To);*/
               
                mail.From = new MailAddress("Admin@Glenwoodmedicalcenter.com");
                if(!string.IsNullOrEmpty(emails.Cc))
                {
                    string[] CCId = emails.Cc.Split(',');
                    foreach (string CCEmail in CCId)
                    {

                        mail.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id                    
                    }
                }
                if(!string.IsNullOrEmpty(emails.Bcc))
                {
                    string[] bccid = emails.Bcc.Split(',');
                    foreach (string bccEmailId in bccid)
                    {

                        mail.Bcc.Add(new MailAddress(bccEmailId)); //Adding Multiple BCC email Id
                    }
                }
                #region
                /* if (emails.Cc == null)
                {
                    mail.CC.Add("null@email.com");
                }
                else
                {
                    string[] CCId = emails.Cc.Split(',');
                    foreach (string CCEmail in CCId)
                    {
                        
                        mail.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id                    
                    }
                }*/

                /*  if (emails.Bcc == null)
                  {
                      mail.Bcc.Add("null@email.com");
                  }
                   else
                  {
                      string[] bccid = emails.Bcc.Split(',');
                      foreach (string bccEmailId in bccid)
                      {
               
                            mail.Bcc.Add(new MailAddress(bccEmailId)); //Adding Multiple BCC email Id
                      }

                  }
          */
                #endregion
                #region
                //else
                //{
                //    mail.CC.Add(emails.Cc);
                //}
                //if (emails.Bcc == null)
                //{
                //    mail.Bcc.Add("null@email.com");
                //}
                //else
                //{
                //    mail.Bcc.Add(emails.Bcc);
                //}
                #endregion

                if(!string.IsNullOrEmpty(emails.Subject))
                {
                    mail.Subject = emails.Subject;
                }
               /* if (emails.Subject == null)
                {
                    mail.Subject = "No subject";
                }
                else
                {
                    mail.Subject = emails.Subject;
                }
                */
                string Body = emails.Body;
                mail.Body = Body;
               
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                #region configurations is in the web.config
                /* smtp.Host = "localhost";//"smtp.live.com"; 
                //smtp.Host = "smtp.live.com";
               
                smtp.Port = 25; //587;
               // smtp.Port=587;
                */
                #endregion
                
                
                smtp.Host = "smtp.sendgrid.net";
                smtp.Port = 2525;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("bigiayomide", "123adenike");// enter seders user name and password
               
               
               
                smtp.Send(mail);

                if (emails.emailID == 0)
                {
                    Email_services _email = new Email_services
                    {
                        emailID = emails.emailID,
                        To = emails.To,
                        Cc = emails.Cc,
                        Bcc = emails.Bcc,
                        Subject = emails.Subject,
                        StaffName=emails.StaffName,
                        Body = emails.Body
                    };

                    emailrepo.Create(_email);
                }
            }
        }

        #region GETdeleteMethod...
        public Email_serviceViewModel GETdeleteMethod(int id)
        {
           Email_serviceViewModel ma = new Email_serviceViewModel();

            using (var mailrepo = new EmailRepository())
            {
                if (id != 0)
                {
                    Email_services _email = mailrepo.GetById(id);

                    ma.emailID = _email.emailID;
                    ma.Cc=_email.Cc;
                    ma.Body=_email.Body;
                    ma.To=_email.To;
                    ma.Bcc = _email.Bcc;
                    ma.Subject=_email.Subject;
                    ma.StaffName = _email.StaffName;
                }
                return ma;
            }
        }
        #endregion

        #region PostDeleteMethod...
       public void PostDeleteMethod(int id)
        {
            using (var deprepo = new EmailRepository())
            {
                if (id != 0)
                {
                    Email_services _email = deprepo.GetById(id);
                    deprepo.Delete(_email);
                }
            }
        }
        #endregion
        #region

        /* public Email_serviceViewModel GETeditemail(int? id)
        {
            Email_serviceViewModel cv = new Email_serviceViewModel();

            using (var emailrepo = new Email_servicesRepository())
            {
                if (id.HasValue && id != 0)
                {
                    Email_services email = emailrepo.GetById(id.Value);

                    cv.emailID = email.emailID;
                    cv.To = email.To;
                    cv.Cc = email.Cc;
                    cv.Body = email.Body;
                    cv.Subject = email.Subject;
                    
                }
                return cv;
            }

        }

        public Email_serviceViewModel PostEditMethod(Email_serviceViewModel cv)
        {
            using (var emailrepo = new Email_servicesRepository())
            {
                if (cv.emailID == 0)
                {
                    Email_services email = new Email_services
                    {
                        emailID = cv.emailID,
                        Cc = cv.Cc,
                        Body = cv.Body,
                        To = cv.To,
                        Subject = cv.Subject,
                        
                    };

                    emailrepo.Update(email);
                }

                else
                {
                    Email_services emailser = emailrepo.GetById(cv.emailID);

                    emailser.emailID = cv.emailID;
                    emailser.Cc = cv.Cc;
                    emailser.Body = cv.Body;
                    emailser.To = cv.To;
                    emailser.Subject = cv.Subject;
                   

                    emailrepo.Update(emailser);
                }

                return cv;
            }
        }
        */
        #endregion
        public void deletemail(Email_services emails)
        {

            Email_services email_services = db.email_services.Find(emails.emailID);
            db.email_services.Remove(email_services);
            db.SaveChanges();
        }
        #region updateemails
        //public void updateemails(Email_services emails)
        //{

        //}
        #endregion
        public Email_serviceViewModel EmailDetails(int? id)
        {
            Email_serviceViewModel em = new Email_serviceViewModel();
            using (var emailrepo = new EmailRepository())
            {
                if(id.HasValue && id!=0)
                {
                    Email_services ema = emailrepo.GetById(id.Value);
                    em.To = ema.To;
                    em.Cc = ema.Cc;
                    em.Bcc = ema.Bcc;
                    em.Subject = ema.Subject;
                    em.Body = ema.Body;
                    em.StaffName = ema.StaffName;
                    
                }
                return em;
            }

        }
    }
}
