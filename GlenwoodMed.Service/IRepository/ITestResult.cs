using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.IRepository
{
    public interface ITestResult:IDisposable
    {
        Result GetById(Int32 id);
        List<Result> GetAllDownload();
        void FileDownload(int id);
        void Insert(Result model);
        void Update(Result model);
        void Delete(Result model);
        IEnumerable<Result> Find(Func<Result, bool> predicate);
    }
}
