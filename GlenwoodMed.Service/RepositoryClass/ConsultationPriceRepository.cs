using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Service.IRepository;

namespace GlenwoodMed.Service.RepositoryClass
{
    public class ConsultationPriceRepository : IConsultationPriceRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<ConsultationPrice> _clinicRepository;
        public ConsultationPriceRepository()
        {
            _datacontext = new DataContext();
            _clinicRepository = new RepositoryService<ConsultationPrice>(_datacontext);

        }
        public List<ConsultationPrice> Getall()
        {
            return _clinicRepository.GetAll().ToList();
        }
        public ConsultationPrice FindbyId(int id)
        {
           return _clinicRepository.GetById(id);
        }
        public void Create(ConsultationPrice price)
        {
             _clinicRepository.Insert(price);
        }
        public void Update(ConsultationPrice model)
        {
            _clinicRepository.Update(model);
        }
        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
