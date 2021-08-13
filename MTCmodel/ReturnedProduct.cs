using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class ReturnedProduct
    {

        //-------------------------------------------------------------------
        public int ID { get; set; }

        //-------------------------------------------------------------------
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Qtt can't be less than 1 !")]
        public int Quantity { get; set; }

        //-------------------------------------------------------------------
        public DateTime Date { get; set; } //default? now?

        //-------------------------------------------------------------------
        [Required]
        [MaxLength(1000,ErrorMessage ="A reason must be given!")]
        public ReturnedProductReason Reason { get; set; }

        //-------------------------------------------------------------------
        public bool Outlet { get; set; }





        //=============================== foreign key's =========================================
        [Required]
        public string EAN { get; set; }
        public Product Product { get; set; }

        //-------------------------------------------------------------------
        public int OrderLineOUTID { get; set; }

        //-------------------------------------------------------------------

        public int NewOrderLineOUTID { get; set; } //hier nog eens over nadenken

         //-------------------------------------------------------------------


        [Required(ErrorMessage = "ClientId cannot be empty")]
        //identity use nvarchar(450) for the key but save all userskeys in format string(36) 
        //if this give a problem, change it to MaxLength 450 
        [MaxLength(450)]
        public string ClientId { get; set; }
        public Client Client { get; set; }


        //=============================== navigation property's =================================



        //================================ Extra's ==============================================

    }
}
