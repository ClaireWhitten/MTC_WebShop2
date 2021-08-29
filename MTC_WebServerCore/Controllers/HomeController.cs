using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MTC_WebServerCore.Models;
using MTC_WebServerCore.ViewModels.Basket_VM;
using MTC_WebServerCore.ViewModels.Home;
using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MTC_WebServerCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationRepository _repos;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IApplicationRepository appRepos, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _repos = appRepos;
            _userManager = userManager;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}




        //https://localhost:5001?catId=1&sub=true 
        //https://localhost:5001?catId=1&sub=false
        //https://localhost:5001?catId=1
        //public async Task<IActionResult> Index(int? id, [FromQuery(Name = "sub")] bool? isBar)

        [HttpGet]
        public async Task<IActionResult> Index(string searchTerm, int? catId, [FromQuery(Name = "sub")] bool? isShowSubs=false)
        {
            //var catDictionary = await _repos.ProductCategories.GetAllPosiblePaths();

            ////for each product cateogry find its parents and create a path
            //foreach (var category in catDictionary)
            //{

            //    //set the path as the text in the select list
            //    Console.WriteLine(category.Key + "======" + category.Value); 

            //}

            var model = new IndexPageViewModel();


            if (!isShowSubs.HasValue) isShowSubs = false;
            model.ProductsToShow = await _repos.Products.GetProductsByCategoryId(catId, isShowSubs.Value);

            if (searchTerm != null)
            {
                var searchedProducts = await _repos.Products.GetByConditionAsync(p => p.Name.Contains(searchTerm));
                model.ProductsToShow = searchedProducts.Data.ToList();
            }

            return View(model);
        }


        //public async Task<IActionResult> ProductsAsync([FromRoute] int categoryId)

        //{
        //    //Get chosen category
        //    //var
        //    TSDreposResultOneObject<ProductCategorie> result = await _repos.ProductCategories.GetByIdAsync(categoryId);

        //    ProductCategorie chosenCategory = result.Data;

        //    //var
        //    TSDreposResultIenumerable<Product> resultProducts = await _repos.Products.GetByConditionAsync(p => p.CategorieId == categoryId);

        //    //Make into viewModel instead
        //    IEnumerable<Product> allCategoryProducts = resultProducts.Data;

        //    //Make viewmodel with needed properties 
        //    //Make view with page layout and bootstrap


        //}






        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public async Task<IActionResult> ProductDetailsAsync([FromRoute] string id)
        {
            if (Request.Cookies["MyBasket"] == null)
            {
                //ViewBag.message = "niet beschikbaar";
                //niets doen, een leeg model sturen
            }
            else
            {
                //model = await CreateBasketViewModelFromCookieAsync();
                List < BasketCookieContentItem > CokiesContent= ReadBasketCookie();
                foreach (var item in CokiesContent)
                {
                    if (item.EAN == id)
                        ViewBag.BascketCount = item.CNT;
                }
            }
            Product product = (await _repos.Products.GetByIdAsync(id)).Data;
            var vm = new ProductDetailsViewModel
            {
                ClientId = _userManager.GetUserId(HttpContext.User),
                Product = product
            };
            if (product.Images.Count > 0)
            {
                vm.ProductImages = new List<string>();
                foreach (var item in product.Images)
                    vm.ProductImages.Add(string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Image)));
            }
            foreach (var item in vm.Product.ProductReviews)
            {
                item.Client = (await _repos.Clients.GetByIdAsync(item.ClientId)).Data;
            }
            return View(vm);
        }
        //[Authorize(Roles = "Client")]

        [HttpPost]
        public async Task<JsonResult> Comment(CommentViewModel model)
        { 
                ProductReview comment = new ProductReview {
                    DateTime = DateTime.UtcNow,
                    Comment = model.Text,
                    ClientId = model.ClientId,
                    Client =(await _repos.Clients.GetByIdAsync(model.ClientId)).Data,
                ProductEAN =model.EAN,
                Rating=model.Rating
                };
                await _repos.ProductReviews.AddAsync(comment);
               JsonResult result = new JsonResult(new { succes = true });
            
                return result;
            
        }

        private List<BasketCookieContentItem> ReadBasketCookie()
        {
            if (Request.Cookies["MyBasket"] == null) { return new List<BasketCookieContentItem>(); }
            string BasketCookieContent = string.Empty;

            List<BasketViewModel> terug = new List<BasketViewModel>();
            BasketCookieContent = Request.Cookies["MyBasket"];

            //zie Basket.js waarom we dit doen
            BasketCookieContent = BasketCookieContent.Replace("$", "\"");
            BasketCookieContent = BasketCookieContent.Replace("#", ",");

            return JsonSerializer.Deserialize<List<BasketCookieContentItem>>(BasketCookieContent);
        }
    }
}
