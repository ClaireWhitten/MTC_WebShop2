using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class Client : UserFactoryHelper
    {
        //-------------------------------------------------------------------

        [Key]
        [MaxLength(450)]
        public string Id { get; set; }
       
        public ApplicationUser ApplicationUser { get; set; }

        //-------------------------------------------------------------------

        public bool IsActive { get; set; } = true;


        public double DiscountPercentage { get; set; } = 0;


        //=============================== foreign key's =========================================





        //=============================== navigation property's =================================

        public ICollection<Bonus> Bonuses { get; set; } // i think, it's better here a global discount???

        public ICollection<OrderOUT> OrderOUTs { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }

        

        //================================ Extra's ==============================================

    }
}
