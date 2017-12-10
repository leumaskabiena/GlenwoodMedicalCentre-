using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model.ViewModels
{
    public class ReferralModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ref_Id { get; set; }

        public int PatientId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date ")]
        public DateTime Ref_date { get; set; }

        [Required(ErrorMessage = "Enter referred doctor")]
        [Display(Name = "Referred Doctor ")]
        [DataType(DataType.Text)]
        public string Referred_Doctor { get; set; }


        public string Patient_name { get; set; }


        public string Patient_age { get; set; }


        public string Patient_number { get; set; }

        [Required(ErrorMessage = "Enter the reason")]
        [Display(Name = "Reason ")]
        [DataType(DataType.MultilineText)]
        public string Reason { get; set; }

        public string diagnotics { get; set; }
    }
}