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
    public class DependentRepository : IDependentRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Dependent> _depRepository;

        public DependentRepository()
        {
            _datacontext = new DataContext();
            _depRepository = new RepositoryService<Dependent>(_datacontext);

        }

        public Dependent GetById(int id)
        {
            return _depRepository.GetById(id);
        }

        public List<Dependent> GetAll()
        {
            return _depRepository.GetAll().ToList();
        }

        public void Insert(Dependent model)
        {
            _depRepository.Insert(model);
        }

        public void Update(Dependent model)
        {
            _depRepository.Update(model);
        }

        public void Delete(Dependent model)
        {
            _depRepository.Delete(model);
        }

        public IEnumerable<Dependent> Find(Func<Dependent, bool> predicate)
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
