using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model.ViewModels
{
    public class ConsultationDrugView
    {
        [Key]
        public int DrugToConsultId { get; set; }
        public int PrescriptionId { get; set; }
        public int DrugId { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Drug Name")]
        public string DrugName { get; set; }
        public string Error { get; set; }
    
    }
}
