using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;



namespace GlenwoodMed.Data.Tables
{
    public class FileUploadDBModel
    {
       // [Required]
        [Key]
        public int FileId { get; set; }
        [DisplayName("Select File to Upload")]
        public IEnumerable<HttpPostedFileBase> File { get; set; }
        public string FileName { get; set; }
        public byte[] ModelFile { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public string patientName { get; set; }

        public virtual Patient Patient { get; set; }
    }
    public class PatientFile
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }
        public int PatientId { get; set; }
        public string patientName { get; set; }
    }
    
}
