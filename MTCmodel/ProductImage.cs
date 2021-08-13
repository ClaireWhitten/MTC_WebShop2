using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MTCmodel
{
    public  class ProductImage
    {
        //-------------------------------------------------------------------
        [Key]
        public string ID { get; set; }

        public byte[] Image { get; set; }



        //=============================== foreign key's =========================================

        [Required]
        //identity use nvarchar(450) for the key but save all userskeys in format string(36) 
        //if this give a problem, change it to MaxLength 450 
        public string ProductEAN { get; set; }


        [Required]
        public Product Product { get; set; }

        //=============================== navigation property's =================================


        //================================ Extra's ==============================================

    }
}
