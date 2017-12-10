using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Model.ViewModels
{
    public class RoleModel
    {
        [Display(Name = "Username")]
        [StringLength(100)]
        public string Username { get; set; }

        [Display(Name = "Rolename")]
        [StringLength(100)]
        public string Rolename { get; set; }




    }
}
