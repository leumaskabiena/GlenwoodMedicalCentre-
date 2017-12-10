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
    public class EmailRepository : IEmailRepository
    {
        private DataContext emailContext=null;
        private readonly IRepository<Email_services> email_serviceRepository;

        public EmailRepository()
        {
            emailContext = new DataContext();
            email_serviceRepository= new RepositoryService<Email_services>(emailContext);
        }
        public List<Email_services> GetAllEmail()
        {
            return email_serviceRepository.GetAll().ToList();
        }

        public Email_services GetById(int id)
        {
            return email_serviceRepository.GetById(id);
        }

        public void Create(Email_services email_service)
        {
            email_serviceRepository.Insert(email_service);
        }

        public void Delete(Email_services email_service)
        {
            email_serviceRepository.Delete(email_service);
        }
        public void Dispose()
        {
            emailContext.Dispose();
            emailContext = null;
        }
    }
}
