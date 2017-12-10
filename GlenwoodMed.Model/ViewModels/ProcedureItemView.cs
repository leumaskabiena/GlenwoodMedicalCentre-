using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMed.Model.ViewModels
{
    public class ProcedureItemView
    {
        [Key]
        public int ProcedureitemID { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public virtual ProcedureView Procedures { get; set; } 
    }
}
