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
    public class SymptomRepository : ISymptomRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Symptoms> _drugRepository;

        public SymptomRepository()
        {
            _datacontext = new DataContext();
            _drugRepository = new RepositoryService<Symptoms>(_datacontext);

        }

        public Symptoms GetById(int id)
        {
            return _drugRepository.GetById(id);
        }

        //giving me error
        public List<Symptoms> GetAll()
        {
            return _drugRepository.GetAll().ToList();
        }

        public void Insert(Symptoms model)
        {
            _drugRepository.Insert(model);
        }

        public void Update(Symptoms model)
        {
            _drugRepository.Update(model);
        }

        public void Delete(Symptoms model)
        {
            _drugRepository.Delete(model);
        }

        //public void Delete(int id)
        //{
            
        //    _drugRepository.Delete(model);
        //  //var Existing = _datacontext.Drugs.Find(id);
        //  //  _datacontext.Drugs.Remove(Existing);
        //}

        public IEnumerable<Symptoms> Find(Func<Symptoms, bool> predicate)
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



        public IEnumerable<Symptoms> Find(Func<Drug, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
