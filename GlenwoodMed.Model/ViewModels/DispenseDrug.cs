using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model.ViewModels
{
   public  class DispenseDrug
    {
        public DispenseDrug()
        {
            this.DispenseCusts = new HashSet<DispenseDrug.DispenseCust>();

        }
        [Key]
        public string ConsultId { get; set; }
        public int PatientId { get; set; }
        public int DrugId { get; set; }
        public int PriceId { get; set; }
        //[Required]
        //[StringLength(30, ErrorMessage = "Enter a name not more than 30 characters", MinimumLength = 3)]
        //[DisplayName("First Name")]
        //public string PatientFname { get; set; }

        //[Required]
        //[StringLength(30, ErrorMessage = "Enter a name not more than 30 characters", MinimumLength = 3)]
        //[DisplayName("Surname")]
        //public string PatientSname { get; set; }

        //[Required]
        [DisplayName("Illness")]
        public string illness { get; set; }

        [Required]

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

        public decimal TestTypePrice { get; set; }

        public decimal ProcedurePricee { get; set; }
        //{
        //    get { return DateTime.Today; }
        //}
        public string FileName { get; set; }
        public byte[] resultFile { get; set; }
        public FileType FileType { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        [DisplayName("Test Type")]
        public string Testtype { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }


        public bool collected { get; set; }

        public string patientfullname { get; set; }
        //[NotMapped]
        //public CustModel custmodel { get; set; }
        //[NotMapped]
        //public class CustModel
        //{
        //    public Cust cust { get; set; }
        //    public List<Cust> CustList { get; set; }
        //}
        public ICollection<DispenseDrug.DispenseCust> DispenseCusts { get; set; }
        public List<DispenseDrug.DispenseCust> Positions { get; set; }
        public List<DispenseDrug.TestType> TestTypes { get; set; }
        public DispenseDrug.TestType TestTyp { get; set; }
        public List<DispenseDrug.procedure> procedures { get; set; }
        public List<DispenseDrug.Illness> Illnesses { get; set; }
        public DispenseDrug.procedure proprocedure { get; set; }

        public void CreateCusts(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                DispenseCusts.Add(new DispenseDrug.DispenseCust());
            }
        }
        public class procedure
        {
            public int procedureid { get; set; }
            public string procedurename { get; set; }
            public bool assigned { get; set; }
            public decimal procedureprice { get; set; }
        }
        public class DispenseCust 
        {
            public string custId { get; set; }
            public string DrugId { get; set; }

            [Required(ErrorMessage = "The dosage field is required")]
            public string Dosage { get; set; }
            [Required(ErrorMessage = "The quantity field is required")]
            public int Quantity { get; set; }
            public bool deleteCust { get; set; }
        }

        public class TestType
        {
            [Key]
            public int TestTypeID { get; set; }

            [DataType(DataType.Text)]
            public string Name { get; set; }

            [DataType(DataType.Currency)]
            public decimal Price { get; set; }

            [DataType(DataType.Text)]
            public string Description { get; set; }
        }

        public class Illness
        {
            public int Illnessid { get; set; }
            public string Illnessname { get; set; }
        }
    }
}
