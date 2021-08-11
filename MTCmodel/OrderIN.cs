using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTCmodel
{
    

    public class OrderIN
    {
        //-------------------------------------------------------------------
        [Key]
        public int ID { get; set; }
        //-------------------------------------------------------------------
        
        public DateTime Date { get; set; }  = DateTime.Now;
        //-------------------------------------------------------------------

        [Required(ErrorMessage = "Status can't be empty!")]
        public StatusOfOrder Status{ get; set; } = StatusOfOrder.Reserved;
        //-------------------------------------------------------------------




        //=============================== foreign key's =========================================
        public int SupplierID { get; set; } 



        //=============================== navigation property's =================================

        public ICollection<OrderLineIN> OrderLinesINs { get; set; }


        //================================ Extra's ==============================================
    }
}
