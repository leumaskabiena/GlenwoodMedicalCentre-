using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Data;
using GlenwoodMed.Service.IRepository;
namespace GlenwoodMed.Service.RepositoryClass
{
    public class HIVTestUploadRepository : IHIVTestUploadRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<HIVPatientFile> _HIVTestUploadRepository;

        public HIVTestUploadRepository()
        {
            _datacontext = new DataContext();
            _HIVTestUploadRepository = new RepositoryService<HIVPatientFile>(_datacontext);
        }

        public HIVPatientFile GetById(Int32 id)
        {
            return _HIVTestUploadRepository.GetById(id);
        }
        public List<HIVPatientFile> GetAllDownloadedFiles()
        {
           return _HIVTestUploadRepository.GetAll().ToList();
        }

        public void FileDownload(int id)
        {
            _HIVTestUploadRepository.GetById(id);
        }
        public void Insert(HIVPatientFile model)
        {
            _HIVTestUploadRepository.Insert(model);
        }
        public void Update(HIVPatientFile model)
        {
            _HIVTestUploadRepository.Update(model);
        }
        public void Delete(HIVPatientFile model)
        {
            _HIVTestUploadRepository.Delete(model);
        }
        public IEnumerable<HIVPatientFile> Find(Func<HIVPatientFile, bool> predicate)
        {
            return _HIVTestUploadRepository.Find(predicate).ToList();
        }
        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
