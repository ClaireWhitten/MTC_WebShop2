using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    public class OrderLineOUT
    {
        //------------------------------------------------------------------- key attribute added
        [Key]
        public int Id { get; set; }

        //-------------------------------------------------------------------
        [Required(ErrorMessage = "Quantity cannot be empty")]
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }

        //-------------------------------------------------------------------
        [Required(ErrorMessage = "Unit Price cannot be empty")]
        [Range(0, double.MaxValue)]
        public double UnitPrice { get; set; }
        //-------------------------------------------------------------------
        [Required]
        public StatusOfOrder Status { get; set; } = StatusOfOrder.Reserved;
        //-------------------------------------------------------------------




        //=============================== foreign key's =========================================
        //foreign key
        [Required(ErrorMessage = "Transporter cannot be empty")]
        public int TransporterId { get; set; }
        public Transporter Transporter { get; set; }

        //-------------------------------------------------------------------
        [Required(ErrorMessage = "Product cannot be empty")]
        public string ProductEAN { get; set; }
        public Product Product { get; set; }

        //-------------------------------------------------------------------
        [Required(ErrorMessage = "Product cannot be empty")]
        public int OrderOUTId { get; set; }
        public OrderOUT OrderOUT { get; set; }

        //=============================== navigation property's =================================



        //================================ Extra's ==============================================



    }
}
