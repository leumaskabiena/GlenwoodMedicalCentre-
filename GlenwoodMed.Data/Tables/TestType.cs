using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class TestType
    {
       
        [Key]
        public int TestTypeID { get; set; }

        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

         [DataType(DataType.Text)]
        public string Description { get; set; }

         public virtual List<Consultation> Consultations { get; set; } 
    }
}
