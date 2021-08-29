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


        //-------------------------------------------------------------------
        [Required]
        [MaxLength(30, ErrorMessage = "lengte maximum 30")]
        [MinLength(2, ErrorMessage = "lengte minimum 2")]
        public string FirstName { get; set; }


        //-------------------------------------------------------------------
        [MaxLength(8, ErrorMessage = "lengte maximum 8")]
        public string NameAdditional { get; set; }


        //-------------------------------------------------------------------
        [Required]
        [MaxLength(30, ErrorMessage = "lengte maximum 30")]
        [MinLength(2, ErrorMessage = "lengte minimum 2")]
        public string LastName { get; set; }

        //-------------------------------------------------------------------

        //public bool IsActive { get; set; } = true; //staat nu in  ApplicationUser



        //-------------------------------------------------------------------
        [Range(0,25, ErrorMessage = "moet tussen 0 en 25 zijn")]
        public double DiscountPercentage { get; set; } = 0;


        //=============================== foreign key's =========================================


        public ApplicationUser ApplicationUser { get; set; }
        //public string UserId { get; set; } //changed to string (from int)


        //=============================== navigation property's =================================

        public ICollection<Bonus> Bonuses { get; set; } // i think, it's better here a global discount???

        public ICollection<OrderOUT> OrderOUTs { get; set; }

        public ICollection<ProductReview> ProductReviews { get; set; }


        public ICollection<ChatMessage> ChatMessages { get; set; }

        //================================ Extra's ==============================================

    }
}
