using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
   public  interface IUploadBussiness
    {
        //void FileDownload(int id);
        //List<UploadViewModel> GetAllDownload();
       void InsertMethod(FileUploadDBModel model, int  PatientId);

       List<FileUploadDBModel> GetAllFiles();
        //FileUploadDBModel GetClinicId(int? id);
        //FileUploadDBModel DetailsMethod(int? id);
        //void InsertMethod(FileUploadDBModel model);
        //FileUploadDBModel GETeditMethod(int? id);
        //FileUploadDBModel PostEditMethod(FileUploadDBModel cv);
        //FileUploadDBModel GETdeleteMethod(int id);
        void PostDeleteMethod(int id);
    }
}
