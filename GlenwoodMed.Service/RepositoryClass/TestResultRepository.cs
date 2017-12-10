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
   public  class TestResultRepository:ITestResult
    {
       private DataContext _datacontext = null;
       private readonly IRepository<Result> _uploadFileRepository;


        public TestResultRepository()
        {
            _datacontext = new DataContext();
            _uploadFileRepository = new RepositoryService<Result>(_datacontext);
        }

        public void FileDownload(int id)
        {
            _uploadFileRepository.GetById(id);
        }

        public List<Result> GetAllDownload()
        {
            return _uploadFileRepository.GetAll().ToList();
        }
        public void Insert(Result model)
        {
            _uploadFileRepository.Insert(model);
        }

        public Result GetById(int id)
        {
            return _uploadFileRepository.GetById(id);
        }

        public void Update(Result model)
        {
            _uploadFileRepository.Update(model);
        }

        public void Delete(Result model)
        {
            _uploadFileRepository.Delete(model);
        }

        public IEnumerable<Result> Find(Func<Result, bool> predicate)
        {
            return _uploadFileRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
