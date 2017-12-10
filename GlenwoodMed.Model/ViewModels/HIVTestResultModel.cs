using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model.ViewModels
{
    public class HIVTestResultModel
    {
        [Key]
        [Display(Name = "Test ID")]
        public int TestId { get; set; }
        [Required]
        [Display(Name = "Client Name")]
        public string PatientName { get; set; }
        [Required]
        [Display(Name = "Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Required]
        [Display(Name = "Testing Location")]
        public string TestigLocation { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Follow-Up Appointment")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime NextAppointment { get; set; }
        public int PatientId { get; set; }
        [Required]
        [Display(Name = "HIV Test Type")]
        public string HIVtestType { get; set; }
        [Display(Name = "Status")]
        [Required]
        public string Status { get; set; }
    }

    public class HIVUploadViewModel
    {

        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }



    }
}
