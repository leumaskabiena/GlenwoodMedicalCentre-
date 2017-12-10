using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlenwoodMedicalCentre.Models
{
    public class ConsultationData
    {
       
            public IEnumerable<Consultation> Consultations { get; set; }
            public IEnumerable<Symptoms> Symptomses { get; set; }
        
    }
}