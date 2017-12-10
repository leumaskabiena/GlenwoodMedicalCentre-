using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Service.IRepository;

namespace GlenwoodMed.Service.RepositoryClass
{
    public class ConsultationRepository:IConsultationRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Consultation> _clinicRepository;

        public ConsultationRepository()
        {
            _datacontext = new DataContext();
            _clinicRepository = new RepositoryService<Consultation>(_datacontext);

        }

        public DataContext DbContext()
        {
            return _datacontext;
        }
        public Consultation GetById(string id)
        {
            return _clinicRepository.GetById(id);
        }
        public DataContext newcontext()
        {
            return _datacontext;
        }
        public List<Consultation> GetAll()
        {
            return _clinicRepository.GetAll().ToList();
        }

        public void Insert(Consultation model)
        {
            _clinicRepository.Insert(model);
        }

        public void Update(Consultation model)
        {
            _clinicRepository.Update(model);
        }

        public void Delete(Consultation model)
        {
            _clinicRepository.Delete(model);
        }
        
        public IEnumerable<Consultation> Find(Func<Consultation, bool> predicate)
        {
            return _clinicRepository.Find(predicate).ToList();
        }
        //public void Save()
        //{
        //    _clinicRepository.Save();
        //}
        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
