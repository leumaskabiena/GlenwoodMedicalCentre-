using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model
{
    public class ClinicView
    {
        [Key]
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
    }
}
