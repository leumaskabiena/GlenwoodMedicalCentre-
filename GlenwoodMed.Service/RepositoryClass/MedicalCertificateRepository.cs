using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.RepositoryClass
{
    public class MedicalCertificateRepository: IMedicalCertificateRepository
    {
        private DataContext MedCertContext = null;
        private readonly IRepository<MedicalCertificate> MedCertRepository;
        public MedicalCertificateRepository()
        {
            MedCertContext = new DataContext();
            MedCertRepository = new RepositoryService<MedicalCertificate>(MedCertContext);

        }
        public List<MedicalCertificate> GetallCertificate()
        {
            return MedCertRepository.GetAll().ToList();
        }
        public MedicalCertificate GetById(int id)
        {
            return MedCertRepository.GetById(id);
        }
        public void Create(MedicalCertificate med)
        {
            MedCertRepository.Insert(med);
        }
        public void Upadte(MedicalCertificate med)
        {
            MedCertRepository.Update(med);
        }
        public void delete(MedicalCertificate med)
        {
            MedCertRepository.Delete(med);
        }
        public void Dispose()
        {
            MedCertContext.Dispose();
            MedCertContext = null;
        }

    }
}
