using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GlenwoodMed.Data.Tables;
using System.Web.Mvc;
namespace GlenwoodMedicalCentre.Models
{
    public class ConsultationSymptomsViewModel
    {
        public Consultation Consultation { get; set; }
        public Symptoms Symptoms { get; set; }
        public IEnumerable<SelectListItem> AllSymptoms { get; set; }
        public Dependent Dependent { get; set; }
        public List<int> _selectedSymptoms;

        public List<int> selectedSymptoms
        {
            get
            {
                if(_selectedSymptoms==null)
                {
                    _selectedSymptoms = Consultation.Symptomses.Select(m => m.Symptomsid).ToList();
                  // _selectedSymptoms=Consultation.Symptoms.Select(m=>m.).ToList();
                }
                return _selectedSymptoms;
            }
            set
            {
                _selectedSymptoms = value;
            }
        }

    }
}