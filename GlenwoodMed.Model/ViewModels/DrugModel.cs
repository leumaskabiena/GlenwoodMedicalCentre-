using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace GlenwoodMed.Model.ViewModels
{
    public class DrugModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrugId { get; set; }

        [Required(ErrorMessage = "Provide the drugs code")]
        [Display(Name = "Code ")]
        public string DrugCode { get; set; }


        [Required(ErrorMessage = "Provide drugs name")]
        [Display(Name = "Drug Name ")]
        public string DrugName { get; set; }

        //[Required(ErrorMessage = "Provide drugs category")]
        [Display(Name = "Category ")]
        public string DrugCategory { get; set; }

        [Required(ErrorMessage = "Select Drug Type")]
        [Display(Name = "Drug Type ")]
        public string DrugType { get; set; }

        [AllowHtml]
        //[Required(ErrorMessage = "Enter drugs description")]
        [Display(Name = "Description ")]
        public string DrugDescription { get; set; }

        [Required(ErrorMessage = "Enter drug quantity")]
        [Display(Name = "Quantity ")]
        public int DrugQuantity { get; set; }

        [Required(ErrorMessage = "Enter drug price")]
        [Display(Name = "Price ")]
        public decimal DrugPrice { get; set; }

        //[Required(ErrorMessage = "Select drugs status")]
        [Display(Name = "Status ")]
        public string Status { get; set; }
    }
}
