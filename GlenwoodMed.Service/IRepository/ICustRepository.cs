using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.Service.IRepository
{
    public interface ICustRepository:IDisposable
    {
        List<Cust> Getall();
        Cust FindbyId(int id);
        void Create(Cust model);
        void Update(Cust model);
        void Delete(Cust model);

    }
}
