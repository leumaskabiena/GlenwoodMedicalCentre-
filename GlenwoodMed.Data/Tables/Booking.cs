using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Display(Name = "Full Name")]
        public string PatientFullName { get; set; }
        public string PatientID { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        //the reason of the booking

        [Display(Name = "Reason of booking")]
        public string Physician { get; set; }
       
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string Date { get; set; }

        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public string Time { get; set; }
        public string Time_start { get; set; }

        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public string Time_end { get; set; }

        public int Status { get; set; }

        public int PatientIdKey { get; set; }
        public string bookingStatus { get; set; }

        public bool notificationStatus { get; set; }
    }
}
//update-database -configurationtypeName GlenwoodMed.Data.DataMigrations.Configuration
//add-migration init -configurationtype GlenwoodMed.Data.DataMigrations.Configuration

