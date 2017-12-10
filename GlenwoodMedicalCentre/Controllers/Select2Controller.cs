using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlenwoodMedicalCentre.Controllers
{
    public class Select2Controller : Controller
    {
         //GET: Select2
       // [HttpGet]
       // public ActionResult GetAttendees(string searchTerm, int pageSize, int pageNum)
        //{
            //Get the paged results and the total count of the results for this query. 
            select2class ar = new select2class();
           // List<Patient> attendees = ar.GetAttendees(searchTerm, pageSize, pageNum);
           // int attendeeCount = ar.GetAttendeesCount(searchTerm, pageSize, pageNum);

            //Translate the attendees into a format the select2 dropdown expects
            //GlenwoodMedicalCentre.Models.Select2Model.Select2PagedResult pagedAttendees = AttendeesToSelect2Format(attendees, attendeeCount);

            //Return the data as a jsonp result
            //return new JsonResult
            //{
            //    Data = pagedAttendees,
            //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //};
        //}
     
         private GlenwoodMedicalCentre.Models.Select2Model.Select2PagedResult AttendeesToSelect2Format(List<Patient> attendees, int totalAttendees)
        {
            GlenwoodMedicalCentre.Models.Select2Model.Select2PagedResult jsonAttendees = new GlenwoodMedicalCentre.Models.Select2Model.Select2PagedResult();
            jsonAttendees.Results = new List<GlenwoodMedicalCentre.Models.Select2Model.Select2Result>();

            //Loop through our attendees and translate it into a text value and an id for the select list
            foreach (Patient a in attendees)
            {
                jsonAttendees.Results.Add(new GlenwoodMedicalCentre.Models.Select2Model.Select2Result { id = a.PatientId.ToString(), text = a.FullName + " " + a.Surname });
            }
            //Set the total count of the results from the query.
            jsonAttendees.Total = totalAttendees;

            return jsonAttendees;
        }
    }
}