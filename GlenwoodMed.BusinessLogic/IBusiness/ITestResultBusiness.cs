using GlenwoodMed.Data.Tables;
using GlenwoodMed.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
   public  interface ITestResultBusiness
    {

        void InsertMethod(TestResult model, int PatientId);

        List<TestResult> GetAllFiles(int PatientId);
        
        void PostDeleteMethod(int id);
       

    
    }
}
