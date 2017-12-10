using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMedicalCentre.Models
{
    public class PrescriptionDrugs
    {
        public List<CollectionView> _CollectionViews { get; set; }  
        public CollectionView _collection { get; set; }
        public List<ConsultationDrug> _ConsultationDrugs { get; set; } 
    }
}