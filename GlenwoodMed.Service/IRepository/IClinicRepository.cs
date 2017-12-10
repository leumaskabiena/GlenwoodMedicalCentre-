using GlenwoodMed.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service
{
    public interface IClinicRepository : IDisposable
    {
        Clinic GetById(Int32 id);
        List<Clinic> GetAll();
        void Insert(Clinic model);
        void Update(Clinic model);
        void Delete(Clinic model);
        IEnumerable<Clinic> Find(Func<Clinic, bool> predicate);
    }
}
