using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMedicalCentre.Models
{
    public class VariableLength
    {
        public ConsultationView consultation { get; set; }
        public CustModel CustModell { get; set; }
        public class CustModel
        {
            public IEnumerable<Cust> CustList { get; set; }
        }

        public class Cust
        {
            public string DrugName { get; set; }

            public double Quantity { get; set; }
            public string Dosage { get; set; }
        }
    }
}