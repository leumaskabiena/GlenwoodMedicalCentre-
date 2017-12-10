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
    public class DrugpropRepository : IDrugpropRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Drug_Properties> _drugRepository;

        public DrugpropRepository()
        {
            _datacontext = new DataContext();
            _drugRepository = new RepositoryService<Drug_Properties>(_datacontext);

        }

        public Drug_Properties GetById(string id)
        {
            return _drugRepository.GetById(id);
        }

        //giving me error
        public List<Drug_Properties> GetAll()
        {
            return _drugRepository.GetAll().ToList();
        }

        public void Insert(Drug_Properties model)
        {
            _drugRepository.Insert(model);
        }

        public void Update(Drug_Properties model)
        {
            _drugRepository.Update(model);
        }

        public void Delete(Drug_Properties model)
        {
            _drugRepository.Delete(model);
        }

        //public void Delete(int id)
        //{

        //    _drugRepository.Delete(model);
        //  //var Existing = _datacontext.Drugs.Find(id);
        //  //  _datacontext.Drugs.Remove(Existing);
        //}

        public IEnumerable<Drug_Properties> Find(Func<Drug_Properties, bool> predicate)
        {
            return _drugRepository.Find(predicate).ToList();
        }

        public void Save()
        {
            _datacontext.SaveChanges();
        }
        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
