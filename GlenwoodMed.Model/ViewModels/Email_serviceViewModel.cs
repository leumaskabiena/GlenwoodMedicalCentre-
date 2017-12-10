using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GlenwoodMed.Model.ViewModels
{
    public class Email_serviceViewModel
    {
        [Key]
        public int emailID { get; set; }
        //[Required]
        //[EmailAddress]
        public string To { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Cc { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Bcc { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Email message")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Body { get; set; }
        public string StaffName { get; set; }
    }
}
