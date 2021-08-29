using Microsoft.AspNetCore.Mvc;
using MTC_WebServerCore.ViewModels.Basket_VM;
//using Newtonsoft.Json;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MTCrepository.TDSrepository;
using MTCmodel;
using Microsoft.AspNetCore.Authorization;

namespace MTC_WebServerCore.Controllers
{
    public class BasketController : Controller
    {

        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationRepository _repos;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //===================================================================================
        //constructor injectie
        public BasketController(RoleManager<ApplicationRole> roleManager,
            IApplicationRepository appRepos,
            SignInManager<ApplicationUser> signInManager,
                                        UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _repos = appRepos;
        }

        //==============================================================================================================
        public async Task<IActionResult> IndexAsync()
        {


            //List<BasketCookieViewmodel> model = new List<BasketCookieViewmodel>();
            BasketViewModel model = new BasketViewModel();

            if (Request.Cookies["MyBasket"] == null)
            {
                //ViewBag.message = "niet beschikbaar";
                //niets doen, een leeg model sturen
            }
            else
            {
                model = await CreateBasketViewModelFromCookieAsync();
            }

            return View(model);
        }

        //===============================================================================================================
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        //===============================================================================================================
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> BillAsync()
        {
            //Als de gebruiker is aangemeld 
            if (_signInManager.IsSignedIn(User))
            {
            
                if (User.IsInRole("Client"))
                {
                    //ff misbruiken die handel, om totaalbedrag etc te vinden
                    BasketViewModel basketViewModel = await CreateBasketViewModelFromCookieAsync();

                    if (basketViewModel.TTpriceIncludeBtw == 0) //de basket is leeg
                    {
                        ViewBag.message = "de basket is leeg";
                        return RedirectToAction("index");
                    }

                    //this gets the at the moment loged in identity, we need the id for capture the client and 
                    //the address for the model
                    ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
                    if (user == null)
                    {
                        throw new Exception("the user is null but User has role client, what's wrong here?");
                    }

                    //we gets the address here, if not found, is null. it's not a problem, we do the nullcheck in de view
                    //this only needed for the values in the textboxes. if we save the orderOut to the DB, we take a hard copy of the
                    //property's of the address, not the reference
                    Address address = null;
                    var ResultAddress = await _repos.Addresses.GetSingleOrDefaultAsync(x => x.ApplicationUser == user);
                    if (ResultAddress.Succeeded)
                    {
                        address = ResultAddress.Data;
                    }

                    //we capture the clientdata, maybe we will show some clientdata on the Billpage
                    Client client = null;
                    var clientResult = await _repos.Clients.GetByIdAsync(user.Id);
                    if ( ! clientResult.Succeeded)
                    {
                        throw new Exception("error by get Clientresult in actionmethode BillAsync from Basketcontroller, what's wrong here?");
                    }
                    client = clientResult.Data;


                    //now we building the model and do the return
                    return View(new BillViewModel { Address = address, BasketViewModel = basketViewModel, Client = client });

                }
                else
                {
                    ViewBag.message = "ingelogd maar niet als client";
                }
            }
            else
            {
                ViewBag.message = "niet ingelogd";
            }
            return View(null);
        }

        //===============================================================================================================

        [Authorize(Roles = "Client")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> PayAsync([FromForm] BillViewModel model)
        {


            //if ( ! ModelState.IsValid)
            //{
            //    return View(model);
            //}
            //======================================

            if (model.BasketViewModel.BasketProductsItem.Count == 0)
            {
                throw new Exception("error in BasketController.Pay, the model contains not productitems");
            }

            OrderOUT orderOut = new OrderOUT
            {
                Street = model.Address.Street,
                HouseNumber = model.Address.HouseNumber,
                HouseNumberAdditional = model.Address.HouseNumberAdditional,
                Zipcode = model.Address.ZipCode,
                City = model.Address.City,
                Country = model.Address.Country,
                ClientId= model.Client.Id,
                //Client=model.Client
            };
            orderOut.OrderLineOUTs = new List<OrderLineOUT>();

            foreach (var item in model.BasketViewModel.BasketProductsItem)
            {
                //Id	Quantity	UnitPrice	Status	TransporterId	ProductEAN	OrderOUTId
                OrderLineOUT tmpLine = new OrderLineOUT
                {
                    //Product=item.Product,
                    Quantity = item.CountOfProducts,
                    UnitPrice = item.Product.RecommendedUnitPrice,
                    ProductEAN = item.Product.EAN,
                };
                orderOut.OrderLineOUTs.Add(tmpLine);
            }

            var dbAddResult = await _repos.OrderOUTs.AddAsync(orderOut);

            if (dbAddResult.Succeeded)
            {
                //List<OrderLineOUT> oerderlineouts = orderOut.OrderLineOUTs.ToList();
                //for (int i = 0; i < oerderlineouts.Count; i++)
                //{
                //    oerderlineouts[i].Product.Name= (await _repos.Products.GetByIdAsync(oerderlineouts[i].ProductEAN)).Data.Name;
                //}
                //orderOut.OrderLineOUTs = oerderlineouts;
                ////foreach (var item in orderOut.OrderLineOUTs)
                ////{
                ////    item.Product.Name = (await _repos.Products.GetByConditionAsync(p=>p.EAN==item.ProductEAN)).Data.FirstOrDefault(p=>p.EAN==item.ProductEAN).Name;
                ////}
                //orderOut.Client = (await _repos.Clients.GetByIdAsync(orderOut.ClientId)).Data;
                //var ordot = (await _repos.OrderOUTs.GetById_withOrderlineOutAndClient_Async(orderOut.Id)).Data;
                //PDFInvoice.PDFinvoice.Create(ordot);
                //clear the cookie,
                //go to the payconfirmed page
                Response.Cookies.Delete("MyBasket");
            }

            else
            {
                if(dbAddResult.ErrorCode == TDSreposErrCode.STOCK_UNDERFLOW)
                {
                    ViewBag.StockUnderflow = true;
                    return RedirectToAction("index", "Basket");
                }
                throw new Exception("orderOUt not added to DB");
            }

            return View();
        }



        #region================================================================================================================ Private methods
        private async Task<BasketViewModel> CreateBasketViewModelFromCookieAsync()
        {
            BasketViewModel terug = new BasketViewModel();

            var cookieItems = ReadBasketCookie();
            //ophalen van items uit cookie, dit is niet ok op deze mannier maar omdat er in basket nooit echt veel items 
            //zitten is het VOORLOPIG wel ok,
            foreach (var item in cookieItems)
            {
                var result = await _repos.Products.GetByIdAsync(item.EAN);

                if (result.Succeeded)
                {
                    Product tmpProduct = result.Data;

                    double btwForThisProduct = ((tmpProduct.RecommendedUnitPrice * tmpProduct.BTWPercentage) / 100) * item.CNT;
                    double ttExclForThisProduct = tmpProduct.RecommendedUnitPrice * item.CNT;
                    double ttInclForThisProduct = btwForThisProduct + ttExclForThisProduct;

                    BasketViewModel.BasketProductItem tmpPrdctItm = new BasketViewModel.BasketProductItem
                    {
                        Product = tmpProduct,
                        CountOfProducts = item.CNT,
                        TTexclBtwThisProduct = ttExclForThisProduct,
                        TTbtwThisProduct = btwForThisProduct,
                        TTinclBtwThisProduct = ttExclForThisProduct + btwForThisProduct,
                        ProductImagesrc = tmpProduct.Images.Count > 0 ? string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(tmpProduct.Images.FirstOrDefault().Image)) : null,
                    };

                    terug.BasketProductsItem.Add(tmpPrdctItm);

                    terug.TTpriceExclBtw += ttExclForThisProduct;
                    terug.TTbtw += btwForThisProduct;
                    terug.TTpriceIncludeBtw += ttInclForThisProduct;

                }
            }

            return terug;
        }
        private List<BasketCookieContentItem> ReadBasketCookie()
        {
            if(Request.Cookies["MyBasket"] == null) { return new List<BasketCookieContentItem>(); }
            string BasketCookieContent = string.Empty;

            List<BasketViewModel> terug  = new List<BasketViewModel>();
            BasketCookieContent = Request.Cookies["MyBasket"];

            //zie Basket.js waarom we dit doen
            BasketCookieContent = BasketCookieContent.Replace("$", "\"");
            BasketCookieContent = BasketCookieContent.Replace("#", ",");

            return JsonSerializer.Deserialize<List<BasketCookieContentItem>>(BasketCookieContent);
        }
        #endregion
    }
}

