using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.IRepository
{
    public interface IEmailRepository:IDisposable
    {
        List<Email_services> GetAllEmail();
        Email_services GetById(int id);
        void Create(Email_services email_service);
        void Delete(Email_services email_service);
        
    }
}
