using MTCmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.Home
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public List<string> ProductImages { get; set; }
    }
}
