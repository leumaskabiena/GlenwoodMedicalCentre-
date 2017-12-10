using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GlenwoodMed.Data;
using GlenwoodMed.Data.Tables;
using GlenwoodMedicalCentre.Extentions;

namespace GlenwoodMed.BusinessLogic.Business
{
    public class select2class
    {
        public IQueryable<Patient> Patients { get; set; }

        public select2class()
        {
            Patients = GenerateAttendees();
        }

        //Return only the results we want
        public List<Patient> GetAttendees(string searchTerm, int pageSize, int pageNum)
        {
            return GetAttendeesQuery(searchTerm)
                .Skip(pageSize*(pageNum - 1))
                .Take(pageSize)
                .ToList();
        }

        //And the total count of records
        public int GetAttendeesCount(string searchTerm, int pageSize, int pageNum)
        {
            return GetAttendeesQuery(searchTerm)
                .Count();
        }


        //Our search term
        private IQueryable<Patient> GetAttendeesQuery(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();

            return Patients
                .Where(
                    a =>
                        a.FullName.Like(searchTerm) ||
                        a.Surname.Like(searchTerm) ||
                        a.NationalId.Like(searchTerm)
                );
        }

        //Generate test data
        private IQueryable<Patient> GenerateAttendees()
        {
            DataContext da=new DataContext();
            //Check cache first before regenerating test data
            string cacheKey="attendees";
            if (HttpContext.Current.Cache[cacheKey] != null)
            {
                return (IQueryable<Patient>)HttpContext.Current.Cache[cacheKey];
            }

           
            var Patientses=da.Patients.ToList();

            var result = Patientses.AsQueryable();

            //Cache results
            HttpContext.Current.Cache[cacheKey] = result;

            return result;
        }
    }
}
