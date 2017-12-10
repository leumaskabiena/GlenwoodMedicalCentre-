using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace GlenwoodMed.Model.ViewModels
{
    public class bookingPatient
    {
        [Key]
        public int BookingId { get; set; }


        [Required(ErrorMessage = "Enter your Full Name")]
        [Display(Name = "Full-Name")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Enter your ID number")]
        [Display(Name = "ID Number")]
        public string identification { get; set; }



        [Required(ErrorMessage = "Enter Phone Number")]
        [Display(Name = "Telephone ")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string Telephone { get; set; }


        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Select Physician ")]
        public string Physician { get; set; }

        [Required(ErrorMessage = "Choose Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public string date { get; set; }



        [Display(Name = "Time")]
        public string time { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }

        public int Status { get; set; }
        public bool notification { get; set; }

        public int PatientIdKey { get; set; }
        public string bookingStatus { get; set; }
        public string FileName { get; set; }
        public byte[] resultFile { get; set; }
        public FileType FileType { get; set; }
    }

    public class Schedule
    {
        public int id { get; set; }
        public string text { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
    }

    public class AvailDoctor
    {
        public int id { get; set; }
        public int num { get; set; }
        public string from { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string to { get; set; }
    }
}
