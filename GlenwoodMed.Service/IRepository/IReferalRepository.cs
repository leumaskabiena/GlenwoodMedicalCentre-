using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.IRepository
{
    public interface IReferalRepository : IDisposable
    {
        Referral GetById(Int32 id);
        List<Referral> GetAll();
        void Insert(Referral model);
        void Update(Referral model);
        void Delete(Referral model);
        IEnumerable<Referral> Find(Func<Referral, bool> predicate);
    }
}
