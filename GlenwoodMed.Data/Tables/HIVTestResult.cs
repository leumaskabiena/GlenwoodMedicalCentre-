using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GlenwoodMed.Data.Tables
{
    public class HIVTestResult
    {
        [Key]
        [Display(Name = "Test ID")]
        public int TestId { get; set; }
        [Display(Name = "Client Name")]
        public string PatientName { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Display(Name="Testing Location")]
        public string TestigLocation { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Display(Name = "Follow-Up Appointment")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime NextAppointment { get; set; }
        //public int PatientId { get; set; }
        [Display(Name="HIV Test Type")]
        public string  HIVtestType { get; set; }
        [Display(Name="Status")]
        public string  Status { get; set; }
        public int PatientId { get; set; }


    }

    public class HIVtestUpload
    {
       
        [Key]
        public int FileId { get; set; }
        [DisplayName("Select File to Upload")]
        public IEnumerable<HttpPostedFileBase> File { get; set; }
        public string FileName { get; set; }
        public byte[] ModelFile { get; set; }
        public int PatientId { get; set; }
        public string patientName { get; set; }

    }
    public class HIVPatientFile
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }
        public int PatientId { get; set; }
        public string patientName { get; set; }
    }
}
