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
    public class PatientRepository : IPatientRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Patient> _depRepository;

        public PatientRepository()
        {
            _datacontext = new DataContext();
            _depRepository = new RepositoryService<Patient>(_datacontext);

        }

        public Patient GetById(int id)
        {
            return _depRepository.GetById(id);
        }

        public List<Patient> GetAll()
        {
            return _depRepository.GetAll().ToList();
        }

        public void Insert(Patient model)
        {
            _depRepository.Insert(model);
        }

        public void Update(Patient model)
        {
            _depRepository.Update(model);
        }

        public void Delete(Patient model)
        {
            _depRepository.Delete(model);
        }

        public IEnumerable<Patient> Find(Func<Patient, bool> predicate)
        {
            return _depRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
