using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class ProcedureItem
    {
        [Key]
        public int ProcedureitemID { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public virtual Procedure Procedures { get; set; } 
    }
}
