using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.IRepository
{
    public interface IDrugpropRepository : IDisposable
    {
        Drug_Properties GetById(string id);
        List<Drug_Properties> GetAll();
        void Insert(Drug_Properties model);
        void Update(Drug_Properties model);
        void Delete(Drug_Properties model);
        void Save();
        IEnumerable<Drug_Properties> Find(Func<Drug_Properties, bool> predicate);

    }
}
