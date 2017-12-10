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
    public class UploadRepository : IUploadRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<PatientFile> _uploadFileRepository;


        public UploadRepository()
        {
            _datacontext = new DataContext();
            _uploadFileRepository = new RepositoryService<PatientFile>(_datacontext);
        }

        public void FileDownload(int id)
        {
            _uploadFileRepository.GetById(id);
        }

        public List<PatientFile> GetAllDownload()
        {
            return _uploadFileRepository.GetAll().ToList();
        }
        //public FileUploadDBModel GetById(Int32 id)
        //{
        //    return _uploadFileRepository.GetById(id);
        //}
        public void Insert(PatientFile model)
        {
            _uploadFileRepository.Insert(model);
        }

        public PatientFile GetById(int id)
        {
            return _uploadFileRepository.GetById(id);
        }

        public void Update(PatientFile model)
        {
            _uploadFileRepository.Update(model);
        }

        public void Delete(PatientFile model)
        {
            _uploadFileRepository.Delete(model);
        }

        public IEnumerable<PatientFile> Find(Func<PatientFile, bool> predicate)
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
