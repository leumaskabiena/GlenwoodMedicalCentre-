using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model.ViewModels
{
    public class EditProfileModel
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Staff Firstname")]
        [Display(Name = "First Name")]
        public string FullName { get; set; }

        public string Age { get; set; }

        [Required(ErrorMessage = "Enter Staff Surname")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Choose Title")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        //[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Choose Status")]
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [Required(ErrorMessage = "Enter Date of Birth")]
        [Display(Name = "Date of Birth")]
        //[DataType(DataType.Date)]
        public string DOB { get; set; }

        [Required(ErrorMessage = "Choose Gender")]
        [Display(Name = "Gender")]
        public string Sex { get; set; }

        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Display(Name = "Address 3")]
        public string Address3 { get; set; }

        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "Enter Postal Code")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Display(Name = "Employer")]
        public string Employer { get; set; }

        [Display(Name = "Employer's Telephone")]
        [DataType(DataType.PhoneNumber)]
        public string EmployerTelephone { get; set; }


        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Enter ID Number")]
        [Display(Name = "Identity Number or Passport")]
        public string NationalId { get; set; }

        [Display(Name = "Status (Flag)")]
        public string Status { get; set; }

        [Display(Name = "Patient Allergy(s)")]
        public string PatientAllergy { get; set; }

        [Display(Name = "Medical Aid Name")]
        public string MedicalAidName { get; set; }

        [Display(Name = "Medical Aid Number")]
        public string MedicalAidNo { get; set; }

        public int DependentId { get; set; }

        public string DependentFname { get; set; }

        public string DependentSname { get; set; }

        public DateTime DOB_Dependent { get; set; }

        public string D_Sex { get; set; }

        public string DependentAllergy { get; set; }
    }
}
