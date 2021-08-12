using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class ProductCategorie
    {

        //-------------------------------------------------------------------
        [Key]
        public int ID { get; set; }

        //-------------------------------------------------------------------
        [Required(ErrorMessage ="Name can't be Empty")]
        [MaxLength(50)]
        public string Name { get; set; }

        //-------------------------------------------------------------------


        //-------------------------------------------------------------------
        



        //=============================== foreign key's =========================================
        public int ParentCategorieID { get; set; }
        public ProductCategorie ParentCategorie { get; set; }


        //=============================== navigation property's =================================

        public ICollection<ProductCategorie> SubCategories { get; set; }
        public ICollection<Product> Products { get; set; }

        //================================ Extra's ==============================================
        public override string ToString()
        {
            return Name;
        }
    }
}
