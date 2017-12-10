using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.Service.IRepository
{
    public interface IMedicalCertificateRepository:IDisposable
    {
        List<MedicalCertificate> GetallCertificate();
        MedicalCertificate GetById(int id);
        void Create(MedicalCertificate med);
        void Upadte(MedicalCertificate med);
        void delete(MedicalCertificate med);

    }
}
