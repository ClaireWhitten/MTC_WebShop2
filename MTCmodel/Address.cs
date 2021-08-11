using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MTCmodel
{
    public class Address
    {
        //-------------------------------------------------------------------
        [Key]
        public int ID { get; set; }

        //-------------------------------------------------------------------

        [Required(ErrorMessage = "Street can't be empty")]
        [MaxLength(50)]
        public string Street { get; set; }

        //------------------------------------------------------------------- 

        [Required(ErrorMessage = "House number can't be empty")]
        //[MaxLength(4)]
        public int HouseNumber { get; set; }

        //------------------------------------------------------------------- 

        [MaxLength(6 , ErrorMessage = "the max lengt of {0} is {1}")]
        public string HouseNumberAdditional { get; set; }

        //-------------------------------------------------------------------

        [Required(ErrorMessage = "zipcode can't be empty")]
        [MaxLength(10)]
        public string ZipCode { get; set; }

        //-------------------------------------------------------------------

        [Required(ErrorMessage = "City can't be empty")]
        [MaxLength(50)]
        public string City { get; set; }

        //------------------------------------------------------------------- 

        [Required(ErrorMessage = "Country can't be empty")]
        [MaxLength(56)]
        public string Country { get; set; }

        //------------------------------------------------------------------- //maxlength deleted, this is a primary type, maked nullable

        //[MaxLength(10)]
        public double? Latitude { get; set; }
        //[MaxLength(10)]
        public double? Longitude { get; set; }




        //=============================== foreign key's =========================================

        [Required]
        //identity use nvarchar(450) for the key but save all userskeys in format string(36) 
        //if this give a problem, change it to MaxLength 450 
        [MaxLength(36)] 
        public string UserID { get; set; }
        //===========>> public User User {get; set;}

        //=============================== navigation property's =================================


        //================================ Extra's ==============================================
        public override string ToString()
        {
            return $"{Street} {HouseNumber}/{HouseNumberAdditional}, {ZipCode} {City}, {Country}.";
        }


    }
}
