using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GlenwoodMed.Data.Tables
{
    public class Patient
    {
        public Patient()
        {
            this.PatientAddresses = new HashSet<PatientAddress>();
        }

        [Key]
        public int PatientId { get; set; }

        [Display(Name = "First Name")]
        public string FullName { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        public string Age { get; set; }

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

        [Display(Name = "Patient Allergy(s)")]
        public string PatientAllergy { get; set; }

        [Display(Name = "Medical Aid Name")]
        public string MedicalAidName { get; set; }

        [Display(Name = "Medical Aid Number")]
        public string MedicalAidNo { get; set; }
        public string PatientNo { get; set; }
        public string Role { get; set; }

        public string ContentType { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }

        public GlenwoodMed.Model.ViewModels.FileType FileType { get; set; }
        //public List<Dependent> Dependent { get; set; }
        public DateTime registeredDate { get; set; }
        public virtual ICollection<Dependent> Dependent { get; set; }
        public virtual ICollection<Consultation> Consultation { get; set; }
        public virtual ICollection<PatientFile> PatientFile { get; set; }
        public virtual ICollection<Result> Result { get; set; }
        public virtual ICollection<PatientAddress> PatientAddresses { get; set; }

        internal void CreateAddresses(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                PatientAddresses.Add(new PatientAddress());
            }
        }
        //public virtual ICollection<File> Files { get; set; }
        //public virtual ICollection<FilePath> FilePaths { get; set; }
    }

    public class PatientModelDetails
    {
        [Key]   
        public int Id { get; set; }
        public List<GlenwoodMed.Model.ViewModels.PatientModel> _listuser { get; set; }
        public GlenwoodMed.Model.ViewModels.PatientModel _dropuser { get; set; }
    }
}
