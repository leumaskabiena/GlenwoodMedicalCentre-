using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GlenwoodMed.Model.ViewModels
{
    public partial class PatientModel
    {
        public PatientModel()
        {
            this.PatientAddresses = new HashSet<PatientAddressModel>();
        }

        [Key]
        public int userId { get; set; }

        [Required(ErrorMessage = "Enter Patient Firstname")]
        [Display(Name = "First Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter Patient Surname")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        public string Age { get; set; }

        //[Required(ErrorMessage = "Choose Title")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [DisplayName("Patient Name")]
        public IEnumerable<SelectListItem> DDLName { get; set; }

        [Required(ErrorMessage = "Enter email address")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Choose Status")]
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [Required(ErrorMessage = "Enter Date of Birth")]
        [Display(Name = "Date of Birth")]
        //[DataType(DataType.Date)]
        public string DOB { get; set; }

        //[Required(ErrorMessage = "Choose Gender")]
        [Display(Name = "Gender")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Enter address")]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Display(Name = "Address 3")]
        public string Address3 { get; set; }

        [Display(Name = "Postal Code")]
        //[MaxLength(4)]
        [Required(ErrorMessage = "Enter Postal Code")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        //[MaxLength(10)]
        public string Telephone { get; set; }

        [Display(Name = "Employer")]
        public string Employer { get; set; }

        [Display(Name = "Employer's Telephone")]
        [DataType(DataType.PhoneNumber)]
        //[MaxLength(10)]
        public string EmployerTelephone { get; set; }

        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Enter ID Number")]
        [Display(Name = "Identity Number or Passport")]
        [StringLength(13)]
        public string NationalId { get; set; }

        [Display(Name = "Passport")]
        public string PassportNo { get; set; }

        [Display(Name = "Status (Flag)")]
        public string Status { get; set; }

        [Display(Name = "Patient Allergy(s)")]
        public string PatientAllergy { get; set; }

        [Display(Name = "Medical Aid Name")]
        public string MedicalAidName { get; set; }

        [Display(Name = "Medical Aid Number")]
        public string MedicalAidNo { get; set; }
        public string PatientNo { get; set; }
        [DisplayName("Select pic to upload")]
        public HttpPostedFileBase File { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public byte[] resultFile { get; set; }
        public FileType FileType { get; set; }
        public DateTime registeredDate { get; set; }

        public virtual ICollection<PatientAddressModel> PatientAddresses { get; set; }

        public void CreateAddresses(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                PatientAddresses.Add(new PatientAddressModel());
            }
        }
        //public virtual ICollection<PatientFile> Files { get; set; }
    }

   
}
