using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMedicalCentre.Models
{
    public class ConsultationDetails
    {
       // public List<GlenwoodMed.Data.Tables.Patient> _user { get; set; }
        //public List<GlenwoodMed.Data.ApplicationUser> _user { get; set; }
        public List<Consultation> _Consultation { get; set; }
        public Consultation Consultation { get; set; }
        public List<ConsultationDrug> _ConsultationDrugs { get; set; }
        public List<DependentModel> _DepModel { get; set; }

        public int _Dep { get; set; }
    }
}