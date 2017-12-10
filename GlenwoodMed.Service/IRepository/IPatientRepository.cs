using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.IRepository
{
    public interface IPatientRepository : IDisposable
    {
        Patient GetById(Int32 id);
        List<Patient> GetAll();
        void Insert(Patient model);
        void Update(Patient model);
        void Delete(Patient model);
        IEnumerable<Patient> Find(Func<Patient, bool> predicate);
    }
}
