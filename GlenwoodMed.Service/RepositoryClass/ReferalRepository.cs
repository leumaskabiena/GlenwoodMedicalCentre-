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
    public class ReferalRepository: IReferalRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Referral> _refRepository;

        public ReferalRepository()
        {
            _datacontext = new DataContext();
            _refRepository = new RepositoryService<Referral>(_datacontext);

        }
        public Referral GetById(int id)
        {
            return _refRepository.GetById(id);
        }

        public List<Referral> GetAll()
        {
            return _refRepository.GetAll().ToList();
        }

        public void Insert(Referral model)
        {
            _refRepository.Insert(model);
        }

        public void Update(Referral model)
        {
            _refRepository.Update(model);
        }

        public void Delete(Referral model)
        {
            _refRepository.Delete(model);
        }

        public IEnumerable<Referral> Find(Func<Referral, bool> predicate)
        {
            return _refRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
