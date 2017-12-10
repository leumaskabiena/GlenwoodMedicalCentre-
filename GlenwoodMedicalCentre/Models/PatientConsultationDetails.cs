using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMedicalCentre.Models
{
    public class PatientConsultationDetails
    {
        public List<Consultation> _Consultation{ get; set; }
        public PatientModel _patient { get; set; }
        public List<TestResultModel> _Xray { get; set; }
        public List<HIVTestResultModel> _HIV { get; set; }
        public ConsultationView ConsultationV { get; set; }
        public Consultation Consultation { get; set; }
        public Patient Patient { get; set; }
        public MedicalCertificateModel MedCert { get; set; }
        public ReferralModel Referrals { get; set; }
    }
}