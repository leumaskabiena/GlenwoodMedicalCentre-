using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class PatientAddress
    {
        [Key]
        public int AddressId { get; set; }
        public string Address { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        //public bool DeleteAddress { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
