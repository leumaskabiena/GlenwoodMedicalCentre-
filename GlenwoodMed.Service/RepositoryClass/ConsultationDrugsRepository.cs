using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Service.IRepository;

namespace GlenwoodMed.Service.RepositoryClass
{
    public class ConsultationDrugsRepository : IConsultationDrugsRepository
    {
 private DataContext _datacontext = null;
        private readonly IRepository<ConsultationDrug> _clinicRepository;

        public ConsultationDrugsRepository()
        {
            _datacontext = new DataContext();
            _clinicRepository = new RepositoryService<ConsultationDrug>(_datacontext);

        }

        public List<ConsultationDrug> Getall()
        {
            return _clinicRepository.GetAll().ToList();
        }

        public ConsultationDrug FindbyId(int id)
        {
            return _clinicRepository.GetById(id);
        }

        public void Create(ConsultationDrug model)
        {
            _clinicRepository.Insert(model);
        }

        public void Update(ConsultationDrug model)
        {
            _clinicRepository.Update(model);
        }
        public void Delete(ConsultationDrug model)
        {
            _clinicRepository.Delete(model);
        }
        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
