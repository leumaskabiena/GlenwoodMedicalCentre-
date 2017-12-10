using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class CollectionDrugs
    {
        public CollectionDrugs()
        {
            Drugs = new HashSet<Drug>();
        }
        [Key]
        public int collectionID { get; set; }

        public int PatientID { get; set; }
        public string Prescription { get; set; }

        public string PatientName { get; set; }

        public bool Collected { get; set; }
        public string PaymentType { get; set; }
        public string Dosage { get; set; }
        public virtual ICollection<Drug> Drugs { get; set; }

    }
}
