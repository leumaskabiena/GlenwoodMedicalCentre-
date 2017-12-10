using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class Dependent
    {
        [Key]
        public int DependentId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public string Age { get; set; }
        public string Title { get; set; }
        public string IdentityNo { get; set; }
        public string DependentFname { get; set; }
        public string DependentSname { get; set; }
        public string DependentRole { get; set; }
        
        public string DependentAllergy { get; set; }

        [DataType(DataType.Date)]
        public string DOB_Dependent { get; set; }

        public string Sex { get; set; }
        
        public virtual Patient Patient { get; set; }
    }
}
