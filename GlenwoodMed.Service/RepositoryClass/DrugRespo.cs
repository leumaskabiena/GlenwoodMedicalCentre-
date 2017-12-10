using System;
using System.Collections.Generic;
using System.Linq;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Service.IRepository;

namespace GlenwoodMed.Service.RepositoryClass
{
    public class DrugRespo : IDrugRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Drug> _drugRepository;

        public DrugRespo()
        {
            _datacontext = new DataContext();
            _drugRepository = new RepositoryService<Drug>(_datacontext);

        }

        public Drug GetById(int id)
        {
            return _drugRepository.GetById(id);
        }

        //giving me error
        public List<Drug> GetAll()
        {
            return _drugRepository.GetAll().ToList();
        }

        public void Insert(Drug model)
        {
            _drugRepository.Insert(model);
        }

        public void Update(Drug model)
        {
            _drugRepository.Update(model);
        }

        public void Delete(Drug model)
        {
            _drugRepository.Delete(model);
        }

        //public void Delete(int id)
        //{
            
        //    _drugRepository.Delete(model);
        //  //var Existing = _datacontext.Drugs.Find(id);
        //  //  _datacontext.Drugs.Remove(Existing);
        //}

        public IEnumerable<Drug> Find(Func<Drug, bool> predicate)
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


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

