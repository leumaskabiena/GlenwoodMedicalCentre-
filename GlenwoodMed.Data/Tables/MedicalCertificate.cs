﻿using System;
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
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Patient Name")]
        public string  PatintName  { get; set; }
        [Required]
        [Display(Name = "Opinion and fitness")]
        public string OpinonIllness { get; set; }
        [Required]
        [Display(Name = "Fitness Problem")]
        public string Fitnessproblem { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Starting Date")]
        public string StartingDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public string Enddate { get; set; }
       
        [Display(Name = "Comment")]
        public string  Comment { get; set; }
        //[Required]
        //[Display(Name = "Doctor's Name")]
        //public string Doctorname { get; set; }
        /*[Required]
        [Display(Name = "Address")]
        public string Address { get; set; }*/
        [Required]
        public int PatientId { get; set; }
       // public DateTime datecreated { get; set; }
    }
}
