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
   public  class ImageGallery
    {

        public ImageGallery()
        {
            ImageList = new List<string>();
        }
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<string> ImageList { get; set; }
        //public string PatientName { get; set; }
        //public int PatientId { get; set; }
    }
}
