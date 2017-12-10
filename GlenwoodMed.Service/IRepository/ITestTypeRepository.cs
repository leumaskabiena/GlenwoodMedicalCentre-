using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.Service.IRepository
{
   public interface  ITestTypeRepository:IDisposable
    {
        TestType GetById(int id);
        List<TestType> GetAll();
        void Insert(TestType model);
        void Update(TestType model);
        void Delete(TestType model);
        IEnumerable<TestType> Find(Func<TestType, bool> predicate);
    }
}
