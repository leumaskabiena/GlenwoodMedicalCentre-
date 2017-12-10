using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace GlenwoodMed.Model.ViewModels
{
    public class TestResultModel
    {
        [Key]
        public int ResultId { get; set; }
        [Required(ErrorMessage = "Test code cant be left empty")]
        [Display(Name = "Test Code")]
        public string Test { get; set; }
        [Required(ErrorMessage = "one test type should be selected")]
        [Display(Name = "Test Type")]
        public string TestType { get; set; }
        [Required(ErrorMessage = "Please provide place of examination")]
        [Display(Name = "Place of Testing")]
        public string place { get; set; }
        [Display(Name = "Skeleton and Soft Tissue")]
        [DataType(DataType.MultilineText)]
        public string ray1 { get; set; }
        [Display(Name = "Cardiac Shadow")]
        [DataType(DataType.MultilineText)]
        public string ray2 { get; set; }
        [Display(Name = "Hilar and Lymphatic glands ")]
        [DataType(DataType.MultilineText)]
        public string ray3 { get; set; }
        [Display(Name = "Hemidiaphragms and costophrenic angles")]
        [DataType(DataType.MultilineText)]
        public string ray4 { get; set; }
        [Display(Name = "Lung fields")]
        [DataType(DataType.MultilineText)]
        public string ray5 { get; set; }
        [Required(ErrorMessage = "radiography name should be provided")]
        [Display(Name = "Radiography Name:")]
        [DataType(DataType.Text)]
        public string name1 { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "please fill out postal address")]
        [Display(Name = "Postal Address:")]
        public string postalAddress { get; set; }
        [Display(Name = "Daytime telephone number:")]
        public string telephoneNo { get; set; }
        [Required(ErrorMessage = "Please provide email address")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string emailAddress { get; set; }

        public string  PatientName { get; set; }
        public int PatientId { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}
