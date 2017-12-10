using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Service.RepositoryClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class UploadBusiness : IUploadBussiness
    {
        #region GetPatientNameFiles...
        public List<FileUploadDBModel> GetPatientNameFiles(int id)
        {
            PatientRepository pr = new PatientRepository();
            using (var Filerepo = new UploadRepository())
            {
                int MyId = Convert.ToInt32(id);

                var name = pr.GetAll().Find(x => x.PatientId == MyId);
                return Filerepo.GetAllDownload().Select(x => new FileUploadDBModel()
                {
                    FileId = x.Id,
                    FileName = x.FileName,
                    ModelFile = x.File,
                    patientName=name.FullName + " " + name.Surname
                }).ToList();
            }
        }
        #endregion


        #region GetAllFiles...
        public List<FileUploadDBModel> GetAllFiles()
        {
            using (var Filerepo = new UploadRepository())
            {
                return Filerepo.GetAllDownload().Select(x => new FileUploadDBModel() 
                {
                    FileId = x.Id, 
                    FileName = x.FileName,
                    ModelFile = x.File,
                    patientName=x.patientName
                }).ToList();
            }
        }
        #endregion

        #region InsertFile...
        public void InsertMethod(FileUploadDBModel model, int PatientId)
        {
            PatientFile fileUpload = new PatientFile();
            PatientRepository pr = new PatientRepository();
            //add loop for multiple file upload at same time
            using (var Filerepo = new UploadRepository())
            {
                var name = pr.GetAll().Find(x => x.PatientId == PatientId);
                foreach (var item in model.File)
                {
                    byte[] uploadfile = new byte[item.InputStream.Length];
                    item.InputStream.Read(uploadfile, 0, uploadfile.Length);

                    fileUpload.FileName = item.FileName;
                    fileUpload.File = uploadfile;
                    fileUpload.PatientId = PatientId;
                    fileUpload.patientName = name.FullName + " " + name.Surname;
                    Filerepo.Insert(fileUpload);
                }
            }
        }
        #endregion

        public string Header(int id)
        {
            var Filerepo = new UploadRepository();

            var fileRecord = Filerepo.GetById(id);//.PatientFiles.Find(id);
            var cd = new System.Net.Mime.ContentDisposition
            {
                // fileData = (byte[])fileRecord.File.ToArray(),
                FileName = fileRecord.FileName,

                Inline = false,
            };

            return cd.ToString();
        }

        public PatientFile Find(int id)
        {
            var Filerepo = new UploadRepository();
            return Filerepo.GetById(id);
        }

        #region PostDeleteMethod...
        public void PostDeleteMethod(int id)
        {
            using (var Filerepo = new UploadRepository())
            {
                if (id != 0)
                {
                    PatientFile _file = Filerepo.GetById(id);
                    Filerepo.Delete(_file);
                }
            }
        }
        #endregion
    }
}
