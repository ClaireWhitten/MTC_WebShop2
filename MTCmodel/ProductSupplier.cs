using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MTCmodel
{
    public class ProductSupplier
    {
        //[Key]
        public string ProductEAN { get; set; }
        public Product Product { get; set; }
        //-------------------------------------------------------------
        //[Key]
        [MaxLength(450)]
        public string SupplierID { get; set; }
        public Supplier Supplier { get; set; }
    }
}
