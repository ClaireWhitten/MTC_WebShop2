using MTCmodel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.Product
{
    public class ProductIndexViewModel
    {
        [Key]
        [MaxLength(13,ErrorMessage = "EAN must be 13 digit characters")]
        public string EAN { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage = "maximum {1} characters allowed for Productame")]
        public string Name { get; set; }


        [Required]
        [Range(0, double.MaxValue)]
        public double RecommendedUnitPrice { get; set; }


        public double? SolderPrice { get; set; }


        //[Required]
        //[Range(0, 30, ErrorMessage = "{0} should be between {1} and {2}")]
        //public double BTWPercentage { get; set; }


        [Required(ErrorMessage = "Category cannot be empty")]
        public int CategorieId { get; set; }
        public ProductCategorie Categorie { get; set; }


        //[Required(ErrorMessage = "Product must have at less 1 Supplier")]
        //public ICollection<Supplier> Suppliers { get; set; }


        //public ICollection<ProductImage> ProductImages { get; set; }

        public ProductImage ProductImage { get; set; }

        //[MaxLength(255, ErrorMessage = "maximum {1} characters allowed for Extra info")]
        //public string ExtraInfo { get; set; }

        ////-------------------------------------------------------------------

        //public int MaxStock { get; set; }

        ////-------------------------------------------------------------------

        //public int MinStock { get; set; }

    }
}
