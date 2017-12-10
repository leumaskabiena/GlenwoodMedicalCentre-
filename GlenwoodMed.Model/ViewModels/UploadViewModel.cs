using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace GlenwoodMed.Model.ViewModels
{
   public  class UploadViewModel
    {

        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }
      


    }
}
