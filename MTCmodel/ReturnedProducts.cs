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

        public string EAN { get; set; }

        //-------------------------------------------------------------------
        public int OrderLineOUTID { get; set; }

        //-------------------------------------------------------------------

        public int NewOrderLineOUTID { get; set; } //hier nog eens over nadenken
        //-------------------------------------------------------------------



        //=============================== navigation property's =================================


        //================================ Extra's ==============================================

    }
}
