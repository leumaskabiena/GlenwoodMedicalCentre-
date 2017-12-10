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
    public class IllnessRepository : IIllnessRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Illness> _drugRepository;

        public IllnessRepository()
        {
            _datacontext = new DataContext();
            _drugRepository = new RepositoryService<Illness>(_datacontext);

        }

        public Illness GetById(int id)
        {
            return _drugRepository.GetById(id);
        }

        //giving me error
        public List<Illness> GetAll()
        {
            return _drugRepository.GetAll().ToList();
        }

        public void Insert(Illness model)
        {
            _drugRepository.Insert(model);
        }

        public void Update(Illness model)
        {
            _drugRepository.Update(model);
        }

        public void Delete(Illness model)
        {
            _drugRepository.Delete(model);
        }

        //public void Delete(int id)
        //{
            
        //    _drugRepository.Delete(model);
        //  //var Existing = _datacontext.Drugs.Find(id);
        //  //  _datacontext.Drugs.Remove(Existing);
        //}

        public IEnumerable<Illness> Find(Func<Illness, bool> predicate)
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

