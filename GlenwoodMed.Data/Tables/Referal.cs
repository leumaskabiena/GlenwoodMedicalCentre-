using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class Referral
    {
        [Key]
        public int Ref_Id { get; set; }

        public int PatientId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Ref_date { get; set; }
        public string Referred_Doctor { get; set; }
        public string Patient_name { get; set; }
        public string Patient_age { get; set; }
        public string Patient_number { get; set; }
        [DataType(DataType.MultilineText)]
        public string Reason { get; set; }
    }
}
