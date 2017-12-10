using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.UserAddresses = new HashSet<UserAddress>();
        }

        [Display(Name = "First Name")]
        public string FullName { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        public string Title { get; set; }
        public string Age { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public override string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public string DOB { get; set; }

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

        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Display(Name = "Employer")]
        public string Employer { get; set; }

        [Display(Name = "Employer's Telephone")]
        [DataType(DataType.PhoneNumber)]
        public string EmployerTelephone { get; set; }

        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        [Display(Name = "National ID")]
        public string NationalId { get; set; }

        [Display(Name = "Status (Flag)")]
        public string Status { get; set; }

        public string PatientNo { get; set; }

        [Display(Name = "Patient Allergy(s)")]
        public string PatientAllergy { get; set; }

        [Display(Name = "Medical Aid Name")]
        public string MedicalAidName { get; set; }

        [Display(Name = "Medical Aid Number")]
        public string MedicalAidNo { get; set; }

        public string Role { get; set; }
        //public List<Dependent> Dependent { get; set; }

        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }
}
