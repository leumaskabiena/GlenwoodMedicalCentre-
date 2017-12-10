using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class Cust
    {
        
        [Key]
        public string custId { get; set; }
        public string DrugId { get; set; }
        public string Dosage { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<Consultation> consultation { get; set; }
        public virtual CollectionDrugs ConsultationDrugs { get; set; }
    }
}
