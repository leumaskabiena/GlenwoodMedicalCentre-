using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.Service.IRepository
{
    public interface IHIVTestreultRepository:IDisposable
    {
        List<HIVTestResult> GetAllTest();
        HIVTestResult GetById(int id);
        void Create(HIVTestResult testResult);
        void update(HIVTestResult testResult);
        void Delete(HIVTestResult testResult);
    }
}
