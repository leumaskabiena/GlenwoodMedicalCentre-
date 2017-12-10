using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class Drug_Properties
    {
        [Key]
        public string DrugCode { get; set; }
        public string DrugName { get; set; }
        public string DrugCategory { get; set; }
        public string DrugDescription { get; set; }
    }
}
