using Microsoft.AspNetCore.Mvc.Rendering;
using MTCmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.OrderIn_VM
{
    public class ReplenishStockViewModel
    {

        public Product Product { get; set; }

        public int AmountToOrder { get; set; }

        public List<SelectListItem> Suppliers { get; set; } = new List<SelectListItem>();


        public string SupplierId { get; set; }

    }
}
