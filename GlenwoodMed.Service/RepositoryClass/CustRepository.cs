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
    public class CustRepository : ICustRepository
    {

        private DataContext _datacontext = null;
        private readonly IRepository<Cust> _clinicRepository;

        public CustRepository()
        {
            _datacontext = new DataContext();
            _clinicRepository = new RepositoryService<Cust>(_datacontext);

        }

        public List<Cust> Getall()
        {
            return _clinicRepository.GetAll().ToList();
        }

        public Cust FindbyId(int id)
        {
            return _clinicRepository.GetById(id);
        }

        public void Create(Cust model)
        {
            _clinicRepository.Insert(model);
        }

        public void Update(Cust model)
        {
            _clinicRepository.Update(model);
        }
        public void Delete(Cust model)
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
