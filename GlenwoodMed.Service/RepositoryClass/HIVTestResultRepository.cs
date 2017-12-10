using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Service.IRepository;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Data;

namespace GlenwoodMed.Service.RepositoryClass
{
    public class HIVTestResultRepository:IHIVTestreultRepository
    {
        private DataContext TestResultConetext = null;
        private readonly IRepository<HIVTestResult> Testresultrepository;
        public HIVTestResultRepository()
        {
            TestResultConetext=new DataContext();
            Testresultrepository = new RepositoryService<HIVTestResult>(TestResultConetext);
        }
        public List<HIVTestResult> GetAllTest()
        {
            return Testresultrepository.GetAll().ToList();
        }
        public HIVTestResult GetById(int id)
        {
            return Testresultrepository.GetById(id);
        }
        public void Create(HIVTestResult testResult)
        {
            Testresultrepository.Insert(testResult);
        }
        public void update(HIVTestResult testResult)
        {
            Testresultrepository.Update(testResult);
        }
        public void Delete(HIVTestResult testResult)
        {
            Testresultrepository.Delete(testResult);
        }
        public void Dispose()
        {
            TestResultConetext.Dispose();
            TestResultConetext = null;
        }
    }
}
