using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.IRepository
{
    public interface IUploadRepository : IDisposable
    {
        //FileUploadDBModel GetById(Int32 id);
       //void  FileDownload(int id);
       // List<PatientFile> GetAllDownload();
       // void Insert(FileUploadDBModel model);
       PatientFile GetById(Int32 id);
       List<PatientFile> GetAllDownload();
       void FileDownload(int id);
        void Insert(PatientFile model);
        void Update(PatientFile model);
        void Delete(PatientFile model);
        IEnumerable<PatientFile> Find(Func<PatientFile, bool> predicate);
    }
}
