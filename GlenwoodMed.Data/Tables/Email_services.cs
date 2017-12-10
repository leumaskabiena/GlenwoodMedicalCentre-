using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Mvc;

namespace GlenwoodMed.Data.Tables
{
    public class Email_services
    {
        //this table will be used to store emails
        // these are the field for where the emails will be seved after 
        // it has been sent
        // public int? emailID { get; set; }
        [Key]
        public int emailID { get; set; }
        [Required]
       //[EmailAddress]
        public string To { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull=true)]
        public string Cc { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Bcc { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull=true)]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Email message")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Body { get; set; }
        public string StaffName { get; set; }
        
    }
}
