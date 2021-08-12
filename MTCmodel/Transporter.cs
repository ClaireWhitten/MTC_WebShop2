using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class Transporter
    {

        //-------------------------------------------------------------------
        [Key]
        public int Id { get; set; }

        //-------------------------------------------------------------------
        [Required(ErrorMessage="Name cannot be empty")]
        public string Name { get; set; }






        //=============================== foreign key's =========================================
        [Required]
        [MaxLength(36)]
        public string UserId { get; set; } //changed to string (from int)

        //public User user { get; set; } ff in comment, komt goed :-)



        //=============================== navigation property's =================================

        public ICollection<Zone> Zones { get; set; }
        public ICollection<OrderLineOUT> orderLineOUTs { get; set; }
            


        //================================ Extra's ==============================================


    }
}
