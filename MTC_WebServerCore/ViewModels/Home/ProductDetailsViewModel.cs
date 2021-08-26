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
        public string ClientId { get; set; }

        private double pricewithBTW;

        public double PricewithBTW
        {
            get { return Product.RecommendedUnitPrice+(Product.RecommendedUnitPrice*Product.BTWPercentage/100); }
            set { pricewithBTW = value; }
        }
        private double pricewithSold;

        public double PricewithSold
        {
            get { return Convert.ToDouble(PricewithBTW - (PricewithBTW * Product.SolderPrice / 100)); }
            set { pricewithBTW = value; }
        }
        private double priceSaved;

        public double PriceSaved
        {
            get { return Convert.ToDouble( Product.RecommendedUnitPrice*Product.SolderPrice/100); }
            set { priceSaved = value; }
        }

    }
}
