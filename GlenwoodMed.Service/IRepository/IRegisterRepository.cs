using GlenwoodMed.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.IRepository
{
    public interface IRegisterRepository : IDisposable
    {
        List<ApplicationUser> GetAll();
        ApplicationUser GetById(string id);
        void Update(ApplicationUser model);
    }
}
