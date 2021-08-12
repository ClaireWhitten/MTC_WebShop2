using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class Client : ApplicationUser
    {
        //-------------------------------------------------------------------
        //[Key]
        //public int Id { get; set; }

        //-------------------------------------------------------------------
        [Required]
        public bool IsActive { get; set; } = true;




        //=============================== foreign key's =========================================





        //=============================== navigation property's =================================

        //public ICollection<Bonus> Bonuses { get; set; } // i think, it's better here a global discount???
        public ICollection<OrderOUT> OrderOUTs { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }

        

        //================================ Extra's ==============================================

    }
}
