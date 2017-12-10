using GlenwoodMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic
{
    public interface IClinicBusiness
    {
        List<ClinicView> GetAllClinics();
        ClinicView GetClinicId(int? id);
        ClinicView DetailsMethod(int? id);
        void CreateMethod(ClinicView cv);
        ClinicView GETeditMethod(int? id);
        ClinicView PostEditMethod(ClinicView cv);
        ClinicView GETdeleteMethod(int id);
        void PostDeleteMethod(int id);
    }
}
