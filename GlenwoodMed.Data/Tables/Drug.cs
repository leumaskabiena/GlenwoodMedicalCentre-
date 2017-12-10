using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace GlenwoodMed.Data.Tables
{
    public class Drug
    {
        [Key]
        public int DrugId { get; set; }

        public string DrugCode { get; set; }
        public string DrugName { get; set; }
        public string DrugCategory { get; set; }
        public string DrugDescription { get; set; }
        public int DrugQuantity { get; set; }
        public string Status { get; set; }
        public string DrugType { get; set; }
        public decimal DrugPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<Consultation> Consultations { get; set; }
        public virtual CollectionDrugs CollectionDrugs { get; set; }
    }
}
