using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Service.RepositoryClass
{
    public class SMSRepository: ISMSRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Notification> _SMSRepository;
        public SMSRepository()
        {
            _datacontext = new DataContext();
            _SMSRepository = new RepositoryService<Notification>(_datacontext);

         
        }
        public void sendSMS( Notification notif)
        {
            _SMSRepository.Insert(notif);
        }
        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
