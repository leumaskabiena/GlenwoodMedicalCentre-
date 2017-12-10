using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.Service.IRepository
{
   public  interface IBookingRepository : IDisposable
    {
        //Resquqest booking
        void Insert(Booking model);
        List<Booking> GetAll();
        List<WorkingTime> GetAllTime();
        Booking GetById(Int32 id);
        //Confrim the booking
        void Update(Booking model);
        void Delete(Booking model);
       

    }
}
