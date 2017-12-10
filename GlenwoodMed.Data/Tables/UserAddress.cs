using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.Data.Tables
{
    public class UserAddress
    {
        [Key]
        public int AddressId { get; set; }
        public string Address { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        //public bool DeleteAddress { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
