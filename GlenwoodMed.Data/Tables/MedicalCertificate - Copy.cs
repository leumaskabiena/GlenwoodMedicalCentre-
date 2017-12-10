using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class MedicalCertificate
    {
        [Key]
        public int MedcertificateId { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string  PatintName  { get; set; }
        [Required]
        public string OpinonIllness { get; set; }
        [Required]
        public string Fitnessproblem { get; set; }
        [Required]
        public string StartingDate { get; set; }
        [Required]
        public string Enddate { get; set; }
        [Required]
        public string  Comment { get; set; }
        [Required]
        public string Doctorname { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int PatientId { get; set; }
        public DateTime datecreated { get; set; }
    }
}
