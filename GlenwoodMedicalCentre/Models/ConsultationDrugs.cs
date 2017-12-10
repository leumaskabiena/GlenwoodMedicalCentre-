using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMedicalCentre.Models
{
    public class ConsultationDrugs
    {
        public ConsultationView _ConsultationView { get; set; }
        public List<Drug> _Drug { get; set; } 

    }
}