using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GlenwoodMed.Model.ViewModels
{
    public class PlaceHolderAttribute : Attribute, IMetadataAware
    {
        private readonly string _placeholder;
        public PlaceHolderAttribute(string placeholder)
        {
            _placeholder = placeholder;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["placeholder"] = _placeholder;
        }
    }

    public class MedicalCertificateModel
    {
        [Key]
        public int MedcertificateId { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        [Display(Name="Patient Name")]
        public string PatintName { get; set; }
        [Required]
        [Display(Name = "Opinion Illness")]
        [PlaceHolder("Eg. He was sick with malaria")]
        public string OpinonIllness { get; set; }
        [Required]
        [Display(Name = "Fitness Problem")]
        public string Fitnessproblem { get; set; }
        [Required]
        [Display(Name = "Starting Date")]
        public string StartingDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public string Enddate { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        [Display(Name = "Doctor Name")]
        public string Doctorname { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string FileName { get; set; }
        public byte[] resultFile { get; set; }
        public FileType FileType { get; set; }
        public DateTime datecreated { get; set; }
    }

    public class ExtraMedModel
    {
        public List<MedicalCertificateModel> med { get; set; }
        public int medId { get; set; }
    }
}
