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
    public class ProcedureItemRepository : IProcedureItemRepository
    {
         private DataContext _datacontext = null;
        private readonly IRepository<ProcedureItem> _drugRepository;

        public ProcedureItemRepository()
        {
            _datacontext = new DataContext();
            _drugRepository = new RepositoryService<ProcedureItem>(_datacontext);

        }

        public ProcedureItem GetById(int id)
        {
            return _drugRepository.GetById(id);
        }

        //giving me error
        public List<ProcedureItem> GetAll()
        {
            return _drugRepository.GetAll().ToList();
        }

        public void Insert(ProcedureItem model)
        {
            _drugRepository.Insert(model);
        }

        public void Update(ProcedureItem model)
        {
            _drugRepository.Update(model);
        }

        public void Delete(ProcedureItem model)
        {
            _drugRepository.Delete(model);
        }

        //public void Delete(int id)
        //{
            
        //    _drugRepository.Delete(model);
        //  //var Existing = _datacontext.Drugs.Find(id);
        //  //  _datacontext.Drugs.Remove(Existing);
        //}

        public IEnumerable<ProcedureItem> Find(Func<ProcedureItem, bool> predicate)
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



        public IEnumerable<ProcedureItem> Find(Func<Drug, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
