using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTCmodel;

namespace MTC_WebServerCore.ViewModels.Home
{
    public class IndexPageViewModel
    {
        public List<Product> ProductsToShow { get; set; } = new List<Product>();
    }
}
