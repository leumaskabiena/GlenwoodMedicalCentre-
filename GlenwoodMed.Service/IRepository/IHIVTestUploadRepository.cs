using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;
namespace GlenwoodMed.Service.IRepository
{
    public interface IHIVTestUploadRepository:IDisposable
    {
        
        HIVPatientFile GetById(Int32 id);
        List<HIVPatientFile> GetAllDownloadedFiles();
        void FileDownload(int id);
        void Insert(HIVPatientFile model);
        void Update(HIVPatientFile model);
        void Delete(HIVPatientFile model);
        IEnumerable<HIVPatientFile> Find(Func<HIVPatientFile, bool> predicate);
    }
}
