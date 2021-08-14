using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class Supplier : UserFactoryHelper
    {
        //-------------------------------------------------------------------
        [Key]
        [MaxLength(450)]
        public string Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        //-------------------------------------------------------------------
        [Required(ErrorMessage = "Name can't be empty!")]
        [MaxLength(50)]
        public string Name { get; set; }
        //-------------------------------------------------------------------
        [Required(ErrorMessage = "BTW can't be empty!")]
        [MaxLength(20)]
        public string BTW { get; set; }
        //-------------------------------------------------------------------

        [MaxLength(400)]
        public string WebSite { get; set; }
        //-------------------------------------------------------------------
        public bool IsActive { get; set; } = true;
        //-------------------------------------------------------------------
        [Required(ErrorMessage = "Company number can't be empty!")]
        [MaxLength(20)]
        public string CompanyNummer { get; set; }
        //-------------------------------------------------------------------


        //=============================== foreign key's =========================================


        //=============================== navigation property's =================================

        //public ICollection<Product> Products { get; set; }
        public ICollection<OrderIN> OrdersINs { get; set; }


        //-------------------------------------------------------------------many to many

        //https://stackoverflow.com/questions/46184678/fluent-api-many-to-many-in-entity-framework-core
        //public ICollection<ProductSupplier> SupplierProducts { get; set; }

        public virtual ICollection<Product>Products {get;set;}

        //================================ Extra's ==============================================
    }
}
