using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model.ViewModels
{
   public  class DosageViewModel
    {
        public int collectionID { get; set; }
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public int PatientID { get; set; }
        public string Prescription { get; set; }

        public string PatientName { get; set; }

        public bool Collected { get; set; }
        public decimal PaymentType { get; set; }
        public string Dosage { get; set; }
   
    }
}
