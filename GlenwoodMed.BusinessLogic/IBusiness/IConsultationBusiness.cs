using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
    public interface IConsultationBusiness
    {
        List<ConsultationView> GetAllConsultations(int Id);
        ConsultationView GetConsultationId(int? id);
        ConsultationView DetailsMethod(int? id);
        ConsultationView GETeditMethod(int? id);
        ConsultationView PostEditMethod(ConsultationView cv);
        ConsultationView GETdeleteMethod(int id);
        void PostDeleteMethod(int id);
        List<Consultation> GetConsultations();
        void AddIllness(string name);
        List<ConsultationView> Last2Consultations(int? Patientid);
        ConsultationView CreateMethod(ConsultationView cv, int id);
        //void AddConsultation(ConsultationView cv);
        void AddConsultation(ConsultationView cv, int id, int[] Symptoms, string[] PresribedMed, int[] Testtype, int[] illness, int[] procedures);



    }
}
