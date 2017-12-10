using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlenwoodMed.Model.ViewModels;

namespace GlenwoodMed.Data.Tables
{
    public class Consultation
    {
        //public Consultation()
        //{
        //    Symptomses = new HashSet<Symptoms>();
        //    Drugs = new HashSet<Drug>();
        //    CustLis = new HashSet<Cust>();
        //    Illness = new HashSet<Illness>();
        //    //Procedures = new HashSet<Procedure>();
        //}
        [Key]
        public string ConsultId { get; set; }
        public int PatientId { get; set; }
        //[Required]
        //[StringLength(30, ErrorMessage = "Enter a name not more than 30 characters", MinimumLength = 3)]
        //[DisplayName("First Name")]
        //public string PatientFname { get; set; }

        //[Required]
        //[StringLength(30, ErrorMessage = "Enter a name not more than 30 characters", MinimumLength = 3)]
        //[DisplayName("Surname")]
        //public string PatientSname { get; set; }

        //[Required]
       

      [NotMapped]
        [DisplayName("Symptoms")]
        public string Symptoms { get; set; }

        //[Required]
        [NotMapped]
        [DisplayName("Prescribed Medicine")]
        public string PresribedMed { get; set; }

        public string ConsultTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime ConsultDate { get; set; }

        public string Description { get; set; }
        //{
        //    get { return DateTime.Today; }
        //}

        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }


        public bool collected { get; set; }

        [NotMapped]
        [DisplayName("Illness")]
        public string illne { get; set; }
        public string patientfullname { get; set; }

        public decimal Amountpaid { get; set; }

        public decimal TestTypePrice { get; set; }
        public decimal ProcedurePricee { get; set; }

        //public virtual ConsultationPrice ConsultationPrice { get; set; }
        //public virtual Drug Drug { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Symptoms> Symptomses { get; set; }
        public virtual ICollection<Drug> Drugs { get; set; }
        public virtual ICollection<Cust> CustLis { get; set; }
        public virtual ICollection<TestType> TestTypes { get; set; }
        public virtual ICollection<Illness> Illness { get; set; }
        public virtual ICollection<Procedure> Procedures { get; set; }

        
       
        [NotMapped]
        public CustModel custmodel { get; set; }
        [NotMapped]
        public class CustModel
        {
            public IEnumerable<Cust> CustList { get; set; }
        }
       
    }
}
