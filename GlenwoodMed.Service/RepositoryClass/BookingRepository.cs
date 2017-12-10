using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMed.Service.IRepository;

namespace GlenwoodMed.Service.RepositoryClass
{
    public class BookingRepository : IBookingRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Booking> _BookingRepository;
        private readonly IRepository<WorkingTime> _workingTime;
        public BookingRepository()
        {
            _datacontext = new DataContext();
            _BookingRepository = new RepositoryService<Booking>(_datacontext);
            _workingTime = new RepositoryService<WorkingTime>(_datacontext);
        }
        //resquest booking
        public void Insert(Booking model)
        {
            _BookingRepository.Insert(model);
        }
        //Get all the booking
        public List<Booking> GetAll()
        {
            return _BookingRepository.GetAll().ToList();
        }
        
        public List<WorkingTime> GetAllTime()
        {
            return _workingTime.GetAll().ToList();
        }
        public Booking GetById(int id)
        {
            return _BookingRepository.GetById(id);
        }
     
        public void Update(Booking model)
        {
            _BookingRepository.Update(model);
        }
        public void Delete(Booking model)
        {
            _BookingRepository.Delete(model);
        }
        public IEnumerable<Booking> Find(Func<Booking, bool> predicate)
        {
            return _BookingRepository.Find(predicate).ToList();
        }
        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
