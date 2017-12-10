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
    public class TestTypeRepository : ITestTypeRepository
    {
         private DataContext _datacontext = null;
         private readonly IRepository<TestType> _clinicRepository;

        public TestTypeRepository()
        {
            _datacontext = new DataContext();
            _clinicRepository = new RepositoryService<TestType>(_datacontext);

        }

        public TestType GetById(int id)
        {
            return _clinicRepository.GetById(id);
        }

        public List<TestType> GetAll()
        {
            return _clinicRepository.GetAll().ToList();
        }

        public void Insert(TestType model)
        {
            _clinicRepository.Insert(model);
        }

        public void Update(TestType model)
        {
            _clinicRepository.Update(model);
        }

        public void Delete(TestType model)
        {
            _clinicRepository.Delete(model);
        }

        public IEnumerable<TestType> Find(Func<TestType, bool> predicate)
        {
            return _clinicRepository.Find(predicate).ToList();
        }
        //public void Save()
        //{
        //    _clinicRepository.save();
        //}
        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
