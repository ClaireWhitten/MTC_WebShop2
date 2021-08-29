using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderInController(ILogger<OrderInController> logger, IApplicationRepository repos, UserManager<ApplicationUser> userManager)
        {
            _repos = repos;
            _logger = logger;
            _userManager = userManager;
        }


        //Gets view of products low in stock which need to be ordered
        [HttpGet]
        [Authorize(Roles = "Administrator,SuperAdmin")]
        public async Task<IActionResult> ReplenishStock()
        {
            //get products low in stock which have not been ordered 
            var result = await _repos.Products.GetProductsLowInStock();
            var productsLowInStock = result.Data;
            List<Product> productsnotYetOrdered = new List<Product>();

            foreach (var product in productsLowInStock)
            {
                if(product.OrderLineINs.Count() == 0)
                {
                    productsnotYetOrdered.Add(product);
                }
                else
                {
                    foreach (var orderLineIn in product.OrderLineINs)
                    {
                        if (orderLineIn.Status == StatusOfOrder.Delivered)
                        {
                            productsnotYetOrdered.Add(product);
                        }
                    }
                }
            }
           
            List<ReplenishStockViewModel> vms = productsnotYetOrdered.Select(x => new ReplenishStockViewModel()
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


        //Updates database with new orders (jquery post request used)
        [HttpPost]
        //problem with validating - do not add validation token for tomorrow or will not work (jquery post - need to solve at later date)
        [Authorize(Roles = "Administrator,SuperAdmin")]
        public async Task<IActionResult> ReplenishStock(IEnumerable<ReplenishStockViewModel> orders)
        {
            if (ModelState.IsValid)
            {
                List<ReplenishStockViewModel> replenishStockViewModels = orders.ToList();
                List<OrderIN> orderINPerSupplier = new List<OrderIN>();
                foreach (var order in replenishStockViewModels)
                {
                    //create one order in per chosen supplier
                    if (!orderINPerSupplier.Exists(x => x.SupplierID == order.SupplierId))
                    {
                        OrderIN newOrderIn = new OrderIN()
                        {
                            SupplierID = order.SupplierId
                        };
                        newOrderIn.OrderLinesINs = new List<OrderLineIN>();
                        

                        OrderLineIN newOrderLine = new OrderLineIN()
                        {
                            Quantity = order.AmountToOrder,
                            UnitPrice = order.Product.RecommendedUnitPrice * order.AmountToOrder,
                            ProductID = order.Product.EAN,
                            OrderIN = newOrderIn
                        };
                        newOrderIn.OrderLinesINs.Add(newOrderLine);
                        orderINPerSupplier.Add(newOrderIn);
                    }

                    else
                    {
                        OrderIN existingOrderIn = orderINPerSupplier.Find(x => x.SupplierID == order.SupplierId);
                        OrderLineIN newOrderLine = new OrderLineIN()
                        {
                            Quantity = order.AmountToOrder,
                            UnitPrice = order.Product.RecommendedUnitPrice * order.AmountToOrder,
                            ProductID = order.Product.EAN,
                            OrderIN = existingOrderIn
                        };

                        existingOrderIn.OrderLinesINs.Add(newOrderLine);
                    }

                }

                foreach (var orderIn in orderINPerSupplier)
                {
                    await _repos.OrderINs.AddAsync(orderIn);
                   
                }

               return RedirectToAction(nameof(OverviewOrders));

            }
           
            return View(orders);
        }


        //Gets overview of all orders made
        [HttpGet]
        [Authorize(Roles = "Administrator,SuperAdmin")]
        public async Task<IActionResult> OverviewOrders()
        {
            var result = await _repos.OrderINs.GetAllAsync();
            var allOrders = result.Data;
            return View(allOrders);
        }



        //Gets the details of the OrderlineIns in an orderIn
        [HttpGet]
        [Authorize(Roles = "Administrator,SuperAdmin,Supplier")]
        public async Task<IActionResult> OrderInDetails([FromRoute] int Id)
        {
            var result = await _repos.OrderINs.GetOrderInsWithOrderLines(Id);
            var orderInWithLines = result.Data.ToList()[0];
            return View(orderInWithLines);
        }



        //Gets overview of reserved orders for the supplier
        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Supplier")]
        public async Task<IActionResult> OverviewReservedToSent()
        {
            //get current userid/supplierid that is logged in
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var usersId = user.Id;
            //get the reserved orders for that user/supplier
            var orderInsResult = await _repos.OrderINs.GetByConditionAsync(o => o.Status == StatusOfOrder.Reserved && o.SupplierID == usersId);
            var ordersIn = orderInsResult.Data;
            List<OrderInOverviewViewModel> model = ordersIn.Select(o => new OrderInOverviewViewModel
            {
                OrderIn = o,
                isChecked= false
            }).ToList();
            return View(model);
            
        }


        //Updates the status of the sent orders in db - supplier 
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Supplier")]
        public async Task<IActionResult> OverviewReservedToSent([FromForm] IEnumerable<OrderInOverviewViewModel> model)
        {
            foreach (var order in model)
            {
                if (order.isChecked)
                {
                    var result = await _repos.OrderINs.GetByIdAsync(order.OrderIn.ID);
                    (result.Data).Status = StatusOfOrder.Sent;
                    await _repos.OrderINs.UpdateAsync(result.Data);
                }

            }
            
            return RedirectToAction(nameof(OverviewReservedToSent));
        }


       


        //Gets overview of sent orders for the admin

        [HttpGet]
        //[Authorize(Roles = "SuperAdmin,Administration")]
        [Authorize(Policy = "DeliveredOrderIn")]
        public async Task<IActionResult> OverviewSentToDelivered()
        {
            
            var orderInsResult = await _repos.OrderINs.GetByConditionAsync(o => o.Status == StatusOfOrder.Sent);
            var ordersIn = orderInsResult.Data;
            List<OrderInOverviewViewModel> model = ordersIn.Select(o => new OrderInOverviewViewModel
            {
                OrderIn = o,
                isChecked = false
            }).ToList();
            return View(model);
        }



        //Updates the status of the delivered orders in db - admin
        [ValidateAntiForgeryToken]
        [HttpPost]
        //[Authorize(Roles = "SuperAdmin,Administration")]
        [Authorize(Policy = "DeliveredOrderIn")]
        public async Task<IActionResult> OverviewSentToDelivered([FromForm] IEnumerable<OrderInOverviewViewModel> model)
        {
            foreach (var order in model)
            {
                if (order.isChecked)
                {
                    var result = await _repos.OrderINs.GetOrderInsWithOrderLines(order.OrderIn.ID);
                    var orderIn = result.Data.ToList()[0];
                    orderIn.Status = StatusOfOrder.Delivered;
                    

                    foreach (var orderLineIN in orderIn.OrderLinesINs)
                    {
                        orderLineIN.Product.CountInStock += orderLineIN.Quantity;
                    }
                    await _repos.OrderINs.UpdateAsync(orderIn);
                }

            }

            return RedirectToAction(nameof(OverviewSentToDelivered));
        }


    }
}
