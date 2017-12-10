using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
    public interface IHIVTestUploadBusiness
    {
        void InsertM(HIVtestUpload HIV, int PatientId);
        List<HIVtestUpload> GetAllFiles(int PatientId);
        void PostDeleteM(int id);
    }
}
