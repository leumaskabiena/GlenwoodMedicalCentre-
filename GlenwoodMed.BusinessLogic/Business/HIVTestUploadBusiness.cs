using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Service.RepositoryClass;
using GlenwoodMed.Data;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class HIVTestUploadBusiness: IHIVTestUploadBusiness
    {
        public void InsertM(HIVtestUpload HIV, int PatientId)
        {
            HIVPatientFile upload = new HIVPatientFile();
            PatientRepository patientrep = new PatientRepository();

            using (var PFilerep = new HIVTestUploadRepository())
            {
                var Pname = patientrep.GetAll().Find(x => x.PatientId == PatientId);
                foreach(var Pfile in HIV.File)
                {
                    byte[] uploadfile = new byte[Pfile.InputStream.Length];
                    Pfile.InputStream.Read(uploadfile, 0, uploadfile.Length);
                    upload.FileName = Pfile.FileName;
                    upload.File = uploadfile;
                    upload.PatientId = PatientId;
                    upload.patientName = Pname.FullName + " " + Pname.Surname;
                    PFilerep.Insert(upload);
                }
            }

        }
        public List<HIVtestUpload> GetAllFiles(int PatientId)
        {
            using (var filerep = new HIVTestUploadRepository())
            {
                return filerep.GetAllDownloadedFiles().Where(x => x.PatientId == PatientId).Select(x => new HIVtestUpload()
                {
                    FileId = x.Id,
                    FileName = x.FileName,
                    ModelFile = x.File,
                    patientName = x.patientName
                }).ToList();
            }
        }
        public void PostDeleteM(int id)
        {
            using (var filerep = new HIVTestUploadRepository())
            {
                if (id != 0)
                {
                    HIVPatientFile Pfile = filerep.GetById(id);
                    filerep.Delete(Pfile);
                }

            }

        }
        private DataContext dbcon = new DataContext();
        public string getpatientId(int pID)
        {
            var name = dbcon.Patients.ToList().Find(x => x.PatientId == pID);
            string fullname = name.FullName.ToUpper() + " " + name.Surname.ToUpper();
            return fullname;
        }

        public string Header (int id)
        {
            var Filerep = new HIVTestUploadRepository();
            var filerec = Filerep.GetById(id);
            var fi = new System.Net.Mime.ContentDisposition
            {
                FileName = filerec.FileName,
                Inline = false,
            };
            return fi.ToString();

        }
        public HIVPatientFile Find(int id)
        {
            var filerep = new HIVTestUploadRepository();
            return filerep.GetById(id);
        }

        public List<HIVtestUpload> GetPatientNameFiles(int id)
        {
            PatientRepository pr = new PatientRepository();
            using (var Filerepo = new HIVTestUploadRepository())
            {
                int MyId = Convert.ToInt32(id);

                var name = pr.GetAll().Find(x => x.PatientId == MyId);
                return Filerepo.GetAllDownloadedFiles().Select(x => new HIVtestUpload()
                {
                    FileId = x.Id,
                    FileName = x.FileName,
                    ModelFile = x.File,
                    patientName = name.FullName + " " + name.Surname
                }).ToList();
            }
        }


    }
}
