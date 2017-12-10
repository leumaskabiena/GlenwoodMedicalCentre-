using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class ConsultationDrug
    {
        [Key]
        public int DrugToConsultId { get; set; }
        public int PrescriptionId { get; set; }
        public int DrugId { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string DrugName { get; set; }
 
    }
}
