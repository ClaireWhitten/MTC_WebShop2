using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class OrderLineIN
    {
        //-------------------------------------------------------------------
        [Key]
        public int ID { get; set; }
        //-------------------------------------------------------------------
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Qtt can't be less than 1 !")]
        public int Quantity { get; set; }
        //-------------------------------------------------------------------
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "unitprice can't be less than 0 !")]
        public double UnitPrice { get; set; }
        //-------------------------------------------------------------------
        public StatusOfOrder Status { get; set; } = StatusOfOrder.Reserved;


        //=============================== foreign key's =========================================
        [Required]
        public int OrderINID { get; set; }
        public OrderIN OrderIN { get; set; }
        //-------------------------------------------------------------------
        [Required]
        public string ProductID { get; set; }
        public Product Product { get; set; }
        //-------------------------------------------------------------------



        //=============================== navigation property's =================================


        //================================ Extra's ==============================================
    }
}
