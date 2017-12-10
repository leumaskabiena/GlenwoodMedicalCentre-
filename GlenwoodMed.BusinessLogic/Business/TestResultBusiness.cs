using GlenwoodMed.BusinessLogic.IBusiness;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Service.RepositoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class TestResultBusiness : ITestResultBusiness
    {


        #region GetPatientNameFiles...
        public List<TestResult> GetPatientNameFiles(int id)
        {
            PatientRepository pr = new PatientRepository();
            using (var Filerepo = new TestResultRepository())
            {
                int MyId = Convert.ToInt32(id);

                var name = pr.GetAll().Find(x => x.PatientId == MyId);
                return Filerepo.GetAllDownload().Select(x => new TestResult()
                {
                    ResultId = x.Id,
                    FileName = x.FileName,
                    resultFile = x.File,
                    PatientName=name.FullName + " " + name.Surname
                }).ToList();
            }
        }
        #endregion


        #region GetAllFiles...
        public List<TestResult> GetAllFiles(int PatientId)
        {
            using (var Filerepo = new TestResultRepository())
            {
                return Filerepo.GetAllDownload().Where(x => x.PatientId == PatientId).Select(x => new TestResult() 
                {
                    ResultId = x.Id, 
                    FileName = x.FileName,
                    resultFile = x.File,
                    PatientName=x.PatientName
                }).ToList();
            }
        }
        #endregion

        #region InsertFile...
        public void InsertMethod(TestResult model, int PatientId)
        {
            Result fileUpload = new Result();
            PatientRepository pr = new PatientRepository();
            using (var Filerepo = new TestResultRepository())
            {
                var name = pr.GetAll().Find(x => x.PatientId == PatientId);
                foreach (var item in model.File)
                {
                    byte[] uploadfile = new byte[item.InputStream.Length];
                    item.InputStream.Read(uploadfile, 0, uploadfile.Length);

                    fileUpload.FileName = item.FileName;
                    fileUpload.File = uploadfile;
                    fileUpload.PatientId = PatientId;
                    fileUpload.PatientName = name.FullName + " " + name.Surname;
                    Filerepo.Insert(fileUpload);
                }
            }
        }
        #endregion

        public string Header(int id)
        {
            var Filerepo = new TestResultRepository();

            var fileRecord = Filerepo.GetById(id);
            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = fileRecord.FileName,
                Inline = false,
            };

            return cd.ToString();
        }

        public Result Find(int id)
        {
            var Filerepo = new TestResultRepository();
            return Filerepo.GetById(id);
        }

        #region PostDeleteMethod...
        public void PostDeleteMethod(int id)
        {
            using (var Filerepo = new TestResultRepository())
            {
                if (id != 0)
                {
                    Result _file = Filerepo.GetById(id);
                    Filerepo.Delete(_file);
                }
            }
        }
        #endregion
        private DataContext pb = new DataContext();
        public string Patients(int PatientId)
        {
            var name = pb.Patients.ToList().Find(x => x.PatientId == PatientId);

            string fullname = name.FullName.ToUpper() + " " + name.Surname.ToUpper();
            return fullname;
        }
    }

}
