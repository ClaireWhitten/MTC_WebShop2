using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MTC_WebServerCore.Models;
using MTC_WebServerCore.ViewModels.Home;
using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        [Route("")]
        public async Task<IActionResult> Index(int? catId, [FromQuery(Name = "sub")] bool? isShowSubs=false)
        {
            if (!isShowSubs.HasValue) isShowSubs = false;

            ////=======================================================test
            var testResult = await _repos.ProductCategories.GetAllPosiblePaths();

            foreach (var item in testResult)
            {
                Console.WriteLine(item.Key + " === " + item.Value);
            }
            //===========================================================

            ////========================================================test
            //var testResult2 = await _repos.Products.GetProductsByCategoryId(1, true);


            ////============================================================



            var model = new IndexPageViewModel();

            var xx = await _repos.OrderOUTs.getOrderOutDTO(StatusOfOrder.Reserved);

            //var rrr = await _repos.OrderOUTs.GetSingleOrDefaultAsync(x=>x.Id == 3);

            //foreach (var item in rrr.Data.OrderLineOUTs)
            //{
            //    Console.WriteLine(item.Id);
            //}


            //Console.WriteLine("test");



            //var productsResult = await _repos.Products.GetAllAsync();
            var productsResult = await _repos.Products.GetProductsByCategoryId(catId, isShowSubs.Value);

            model.ProductsToShow = productsResult.Products;



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
            Product product = (await _repos.Products.GetByIdAsync(id)).Data;
            var vm = new ProductDetailsViewModel
            {
                Product = product
            };
            if (product.Images.Count > 0)
            {
                vm.ProductImages = new List<string>();
                foreach (var item in product.Images)
                    vm.ProductImages.Add(string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Image)));
            }
            return View(vm);
        }
    }
}
