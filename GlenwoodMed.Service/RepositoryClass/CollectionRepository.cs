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
    public class CollectionRepository : ICollectionRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<CollectionDrugs> _clinicRepository;

        public CollectionRepository()
        {
            _datacontext = new DataContext();
            _clinicRepository = new RepositoryService<CollectionDrugs>(_datacontext);

        }

        public List<CollectionDrugs> Getall()
        {
            return _clinicRepository.GetAll().ToList();
        }

        public CollectionDrugs FindbyId(int id)
        {
            return _clinicRepository.GetById(id);
        }

        public void Create(CollectionDrugs model)
        {
            _clinicRepository.Insert(model);
        }

        public void Update(CollectionDrugs model)
        {
            _clinicRepository.Update(model);
        }

        public void Delete(CollectionDrugs model)
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
