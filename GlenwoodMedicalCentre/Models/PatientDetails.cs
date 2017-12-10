using GlenwoodMed.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GlenwoodMed.Data;

namespace GlenwoodMedicalCentre.Models
{
    public class PatientDetails
    {
        public List<GlenwoodMed.Data.Tables.Patient> _user { get; set; }
        //public List<GlenwoodMed.Data.ApplicationUser> _user { get; set; }
        //public GlenwoodMed.Data.Tables.PatientModel _myuser { get; set; }
        public GlenwoodMed.Model.ViewModels.PatientModel _myuser { get; set; }
        public List<Dependent> _dependent { get; set; }
        public List<FileUploadDBModel> _file { get; set; }
        //public List<PatientFile> _file { get; set; }
    }
}