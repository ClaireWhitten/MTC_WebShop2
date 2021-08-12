using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class OrderOUT
    {
        //-------------------------------------------------------------------
        [Key]
        public int Id { get; set;}

        //-------------------------------------------------------------------
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        //-------------------------------------------------------------------
        [Required]
        public StatusOfOrder Status { get; set; } = StatusOfOrder.Reserved;


        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //         order address
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public string Street { get; set; }
        //-------------------------------------------------------------------
        [Required(ErrorMessage = "House number can't be empty")]
        [MaxLength(4)]
        public int HouseNumber { get; set; }
        //-------------------------------------------------------------------
        [MaxLength(6)]
        public string HouseNumberAdditional { get; set; }
        //-------------------------------------------------------------------
        [Required(ErrorMessage = "Zip code can't be empty")]
        [MaxLength(10)]
        public string Zipcode { get; set; }
        //-------------------------------------------------------------------
        [Required(ErrorMessage = "City can't be empty")]
        [MaxLength(50)]
        public string City { get; set; }
        //-------------------------------------------------------------------
        [Required(ErrorMessage = "Country can't be empty")]
        [MaxLength(50)]
        public string Country { get; set; }
        //------------------------------------------------------------------
        //[MaxLength(10)]
        public double? Latitude { get; set; }
        //-------------------------------------------------------------------
        //[MaxLength(10)]
        public double? Longitude { get; set; }







        //=============================== foreign key's =========================================

        [Required(ErrorMessage = "ClientId cannot be empty")]
        //identity use nvarchar(450) for the key but save all userskeys in format string(36) 
        //if this give a problem, change it to MaxLength 450 
        [MaxLength(36)]
        public string ClientId { get; set; }
        public Client Client { get; set; }
        //-------------------------------------------------------------------

        //=============================== navigation property's =================================

        public ICollection<OrderLineOUT> OrderLineOUTs { get; set; }


        //================================ Extra's ==============================================


    }
}
