using MTCmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.Basket_VM
{
    public class BillViewModel
    {
        public Address Address { get; set; }
        public BasketViewModel BasketViewModel { get; set; }
        public Client Client { get; set; }
    }
}
