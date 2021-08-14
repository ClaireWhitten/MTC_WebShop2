using MTCmodel.CustomAnnotationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class Product

    {

        //------------------------------------------------------------------- required not needed here, custom EAN attribute writed :-)
        [Key]
        //[Required] //key is allways required, don't needed here
        //[MaxLength(13)]
        //[MinLength(13)]
        [EAN (ErrorMessage = "EAN must be 13 digit characters")]
        public string EAN { get; set; }

        public bool IsActive { get; set; } = true;

        //-------------------------------------------------------------------
        [Required]
        [MaxLength(50, ErrorMessage = "maximum {1} characters allowed for Productame")]
        public string Name { get; set; }

        //------------------------------------------------------------------- max length added

        [MaxLength(255, ErrorMessage = "maximum {1} characters allowed for Extra info")]
        public string ExtraInfo { get; set; }

        //-------------------------------------------------------------------
        [Required]
        [Range(0,30, ErrorMessage = "{0} should be between {1} and {2}")]
        public double BTWPercentage { get; set; }

    
        //------------------------------------------------------------------- Count changed to CountInStock
        public int CountInStock { get; set; }

        //-------------------------------------------------------------------
        public int MaxStock { get; set; }
        //-------------------------------------------------------------------
        public int MinStock { get; set; }
        //-------------------------------------------------------------------



        [Range(0, 5)]
        public double? AverageRating { get; set; } = null;

        //-------------------------------------------------------------------
        [Required]
        [Range(0, double.MaxValue)]
        public double RecommendedUnitPrice { get; set; }

        //-------------------------------------------------------------------

        public double? SolderPrice { get; set; }



        //=============================== foreign key's =========================================

        //foreign key
        [Required(ErrorMessage = "Category cannot be empty")]
        public int CategorieId { get; set; }
        public ProductCategorie Categorie { get; set; }

        //-------------------------------------------------------------------
        //[Required(ErrorMessage = "Supplier cannot be empty")]
        //[MaxLength(450)]
        //public string SupplierId { get; set; }
        //public Supplier Supplier { get; set; }

        //=============================== navigation property's =================================

        //public  ICollection<Supplier> Suppliers { get; set; }

        public ICollection<OrderLineOUT> OrderLineOUTs { get; set; }

        public ICollection<OrderLineIN> OrderLineINs { get; set; }

        public ICollection<ProductReview> ProductReviews { get; set; }

        public ICollection<ReturnedProduct> ReturnedProducts { get; set; }


        public ICollection<ProductImage> Images { get; set; }

        //-------------------------------------------------------------------many to many

        //https://stackoverflow.com/questions/46184678/fluent-api-many-to-many-in-entity-framework-core
        //public ICollection<ProductSupplier> ProductSuppliers { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }

        //================================ Extra's ==============================================

    }
}
