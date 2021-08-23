using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MTC_WebServerCore.ViewModels.OrderIn_VM;
using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.Controllers
{
    public class OrderInController : Controller
    {

        private readonly ILogger<OrderInController> _logger;
        private readonly IApplicationRepository _repos;

        public OrderInController(ILogger<OrderInController> logger, IApplicationRepository repos)
        {
            _repos = repos;
            _logger = logger;
        }


        [HttpGet]  
        public async Task<IActionResult> ReplenishStock()
        {
            var result = await _repos.Products.GetProductsWithSuppliers();
            var products = result.Data;
            var productsLowInStock = products.Where(p => p.IsActive && p.CountInStock <= p.MinStock);
           
            List<ReplenishStockViewModel> vms = productsLowInStock.Select(x => new ReplenishStockViewModel()
            {
                Product = x,
                AmountToOrder = x.MaxStock - x.CountInStock,
            }).ToList();

            foreach (var vm in vms)
            {
                foreach (var supplier in vm.Product.Suppliers)
                {
                    vm.Suppliers.Add(new SelectListItem {Text = supplier.Name, Value = supplier.Id.ToString() });
                }
               
            }

            return View(vms);
        }


        //jquery post request fires this action 
        [HttpPost]
        public async Task<IActionResult> ReplenishStock(IEnumerable<ReplenishStockViewModel> orders)
        {
            if (ModelState.IsValid)
            {
                List<ReplenishStockViewModel> replenishStockViewModels = orders.ToList();
                List<OrderIN> orderINs = new List<OrderIN>();
                foreach (var order in replenishStockViewModels)
                {
                    if (!orderINs.Exists(x => x.SupplierID == order.SupplierId))
                    {
                        OrderIN newOrderIn = new OrderIN()
                        {
                            SupplierID = order.SupplierId
                        };
                        orderINs.Add(newOrderIn);

                        OrderLineIN newOrderLine = new OrderLineIN()
                        {
                            Quantity = order.AmountToOrder,
                            UnitPrice = order.Product.RecommendedUnitPrice * order.AmountToOrder,
                            ProductID = order.Product.EAN,
                            OrderINID = newOrderIn.ID
                        };
                    }

                    else
                    {
                        OrderIN existingOrderIn = orderINs.Find(x => x.SupplierID == order.SupplierId);
                        OrderLineIN newOrderLine = new OrderLineIN()
                        {
                            Quantity = order.AmountToOrder,
                            UnitPrice = order.Product.RecommendedUnitPrice * order.AmountToOrder,
                            ProductID = order.Product.EAN,
                            OrderINID = existingOrderIn.ID
                        };
                    }

                }

                foreach (var orderIn in orderINs)
                {
                    await _repos.OrderINs.AddAsync(orderIn);
                }


                return RedirectToAction(nameof(OrderInOverview));

            }
           

            return View(orders);
        }


        public async Task<IActionResult> OrderInOverview()
        {
            return View();
            //table with order ins and buttons detail - brings you to orderOUT
        }
    }
}
