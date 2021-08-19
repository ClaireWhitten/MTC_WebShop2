using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTCmodel;

namespace MTC_WebServerCore.ViewModels.ProductAdmin
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public string CategoryName { get; set; }
        public List<string> ProductImages { get; set; }
    }
}
