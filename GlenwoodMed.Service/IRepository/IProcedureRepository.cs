using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.Service.IRepository
{
    public interface IProcedureRepository:IDisposable
    {
        Procedure GetById(Int32 id);
        List<Procedure> GetAll();
        void Insert(Procedure model);
        void Update(Procedure model);
        void Delete(Procedure model);
        void Save();
        IEnumerable<Procedure> Find(Func<Procedure, bool> predicate);
    }
}
