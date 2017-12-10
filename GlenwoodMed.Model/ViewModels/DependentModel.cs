using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GlenwoodMed.Model.ViewModels
{
    public class DependentModel
    {
        [Key]
        public int DependentId { get; set; }

        public string Age { get; set; }

        [Required(ErrorMessage = "Choose Title")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter ID Number")]
        [Display(Name = "Identity Number or Passport")]
        public string IdentityNo { get; set; }

        [Required(ErrorMessage = "Enter Dependent FirstName")]
        [DisplayName("Dependent FirstName")]
        public string DependentFname { get; set; }

        [Required(ErrorMessage = "Enter Dependent Surname")]
        [DisplayName("Dependent Surname")]
        public string DependentSname { get; set; }

        [Required(ErrorMessage = "Choose Dependent Role")]
        [DisplayName("Dependent Role")]
        public string DependentRole { get; set; }

        [Required(ErrorMessage = "Enter Dependent Date of Birth")]
        [DisplayName("Dependent DOB")]
        public string DOB_Dependent { get; set; }

        [Required(ErrorMessage = "Select Dependent Gender")]
        [Display(Name = "Gender")]
        public string Sex { get; set; }

        [DisplayName("Patient Name")]
        public IEnumerable<SelectListItem> DDLName { get; set; }

        [DisplayName("Patient Name")]
        public string patientName { get; set; }

        public int PatientId { get; set; }

        [DisplayName("Dependent Allergy(s)")]
        public string DependentAllergy { get; set; }

    }
}
