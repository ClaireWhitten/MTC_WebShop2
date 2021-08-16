using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.ProductAdmin
{
    public class ProductCreateViewModel
    {
        [Key]
        [Required(ErrorMessage = "EAN must be 13 digit characters")]
        public string EAN { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage = "maximum {1} characters allowed for Productame")]
        public string Name { get; set; }


        [MaxLength(255, ErrorMessage = "maximum {1} characters allowed for Extra info")]
        public string ExtraInfo { get; set; }

        //-------------------------------------------------------------------
        [Required]
        [Range(0, 30, ErrorMessage = "{0} should be between {1} and {2}")]
        public double BTWPercentage { get; set; }


        public int CountInStock { get; set; }


        public int MaxStock { get; set; }

        public int MinStock { get; set; }


        [Required]
        [Range(0, double.MaxValue)]
        public double RecommendedUnitPrice { get; set; }
        
        public double? SolderPercentage { get; set; }

        public IFormFileCollection  IImages { get; set; }


        [Required(ErrorMessage = "Category cannot be empty")]
        public int CategorieId { get; set; }
        public ProductCategorie Categorie { get; set; }
        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Suppliers { get; set; }

    }
}
