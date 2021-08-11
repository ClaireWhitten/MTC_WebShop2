using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class Client
    {
        //-------------------------------------------------------------------
        [Key]
        public int Id { get; set; }

        //-------------------------------------------------------------------
        [Required]
        public bool IsActive { get; set; } = true;




        //=============================== foreign key's =========================================
        [Required]
        [MaxLength(36)]
        public string UserId { get; set; } 
        public User User { get; set; } 




        //=============================== navigation property's =================================

        //public ICollection<Bonus> Bonuses { get; set; } // i think, it's better here a global discount???
        public ICollection<OrderOUT> OrderOUTs { get; set; }




        //================================ Extra's ==============================================

    }
}
