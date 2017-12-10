using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
    public interface IMedCertificateBusiness
    {
        List<MedicalCertificateModel> GetallMedCert();
        void create(MedicalCertificateModel med, int PatientId);//, int Pid);
        MedicalCertificateModel GetbyId(int? id);
        MedicalCertificateModel GetEdit(int? id);
        MedicalCertificateModel PostEdit(MedicalCertificateModel id);
        MedicalCertificateModel GetDelete(int? id, MedicalCertificateModel medi);
        void PostDelete(int del);

    }
}
