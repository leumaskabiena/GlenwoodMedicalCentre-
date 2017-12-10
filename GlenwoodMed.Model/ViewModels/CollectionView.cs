using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model.ViewModels
{
    public class CollectionView
    {
        [Key]
        public int collectionID { get; set; }

        public string Prescription { get; set; }

        public string PatientName { get; set; }

        public bool Collected { get; set; }
        public string PaymentType { get; set; }
    }
}
