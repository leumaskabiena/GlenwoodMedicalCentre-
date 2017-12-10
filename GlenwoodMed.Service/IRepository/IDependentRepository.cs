using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.IRepository
{
    public interface IDependentRepository : IDisposable
    {
        Dependent GetById(Int32 id);
        List<Dependent> GetAll();
        void Insert(Dependent model);
        void Update(Dependent model);
        void Delete(Dependent model);
        IEnumerable<Dependent> Find(Func<Dependent, bool> predicate);
    }
}
