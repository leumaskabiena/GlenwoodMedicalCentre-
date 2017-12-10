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
   public  class FeedBackRepository:IFeedbackRepository
    {
       private DataContext _datacontext = null;
        private readonly IRepository<FeedBack> _FeedBackRepository;

        public FeedBackRepository()
        {
            _datacontext = new DataContext();
            _FeedBackRepository = new RepositoryService<FeedBack>(_datacontext);

        }

        public FeedBack GetById(int id)
        {
            return _FeedBackRepository.GetById(id);
        }

        public List<FeedBack> GetAll()
        {
            return _FeedBackRepository.GetAll().ToList();
        }

        public void Insert(FeedBack model)
        {
            _FeedBackRepository.Insert(model);
        }

        public void Update(FeedBack model)
        {
            _FeedBackRepository.Update(model);
        }

        public void Delete(FeedBack model)
        {
            _FeedBackRepository.Delete(model);
            
        }

        public IEnumerable<FeedBack> Find(Func<FeedBack, bool> predicate)
        {
            return _FeedBackRepository.Find(predicate).ToList();
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

