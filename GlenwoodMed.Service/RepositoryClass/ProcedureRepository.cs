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
    public class ProcedureRepository : IProcedureRepository
    {
         private DataContext _datacontext = null;
        private readonly IRepository<Procedure> _drugRepository;

        public ProcedureRepository()
        {
            _datacontext = new DataContext();
            _drugRepository = new RepositoryService<Procedure>(_datacontext);

        }

        public Procedure GetById(int id)
        {
            return _drugRepository.GetById(id);
        }

        //giving me error
        public List<Procedure> GetAll()
        {
            return _drugRepository.GetAll().ToList();
        }

        public void Insert(Procedure model)
        {
            _drugRepository.Insert(model);
        }

        public void Update(Procedure model)
        {
            _drugRepository.Update(model);
        }

        public void Delete(Procedure model)
        {
            _drugRepository.Delete(model);
        }

        //public void Delete(int id)
        //{
            
        //    _drugRepository.Delete(model);
        //  //var Existing = _datacontext.Drugs.Find(id);
        //  //  _datacontext.Drugs.Remove(Existing);
        //}

        public IEnumerable<Procedure> Find(Func<Procedure, bool> predicate)
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



        public IEnumerable<Procedure> Find(Func<Drug, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
