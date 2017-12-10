using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using GlenwoodMed.Model;

namespace GlenwoodMed.Model.ViewModels
{
    public class ReportModel
    {
        public PatientModel _patient { get; set; }
        public List<ConsultationView> _consult { get; set; }
        public List<TestResultModel> _Xray { get; set; }
        public List<HIVTestResultModel> _HIV { get; set; }

    }
}
