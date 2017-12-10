
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Model.ViewModels;
using GlenwoodMed.Data.Tables;

namespace GlenwoodMed.BusinessLogic.IBusiness
{
    public interface IBookingBusiness
    {
        //Resquest Booking

        int PatientExist(string pat);
        bookingPatient FindPatientDetails(int? id);
        void SaveBooking(bookingPatient model);
        List<Schedule> BookingBeforeUpdate();
        bookingPatient GetSaveBooking(int id);
        void InsertSaveBooking(Schedule m, int d);
        void DeleteSavedBooking(int id);
        void UpdateSavedBooking(Schedule sc, Schedule x);
        List<Schedule> displaySchedule();
        void resquestBooking(bookingPatient bo);
        List<bookingPatient> GetAllRequest();
        List<bookingPatient> GetAllBookings();
        bookingPatient GetBooking(int? id);
        Patient GetOne(int PatientId);
        void booking(bookingPatient model, int PatientId);
        List<Schedule> GetAllSchedule();
        int CountMethod();
        void EndConsultaion(int bookingId);
        int Consulted();
        int NotConsulted();
        List<Schedule> display();
    }
}
