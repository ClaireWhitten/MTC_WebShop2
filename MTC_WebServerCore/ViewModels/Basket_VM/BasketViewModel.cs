using MTCmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.Basket_VM
{
    public class BasketViewModel
    {
        //==================================================================== innerclass
        public class BasketProductItem
        {
            public Product Product { get; set; }
            public int CountOfProducts { get; set; }
            public double TTbtwThisProduct { get; set; }
            public double TTinclBtwThisProduct { get; set; }
            public double TTexclBtwThisProduct { get; set; }
            public string ProductImagesrc { get; set; }
        }
        //===============================================================================

        public List<BasketProductItem> BasketProductsItem { get; set; } = new List<BasketProductItem>();

        public double TTpriceExclBtw { get; set; }
        public double TTbtw { get; set; }
        public double TTpriceIncludeBtw { get; set; }
    }
}
