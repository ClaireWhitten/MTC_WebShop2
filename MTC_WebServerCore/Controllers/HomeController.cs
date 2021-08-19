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


        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {

            var model = new IndexPageViewModel();


            //hier kies je welke producten je wil laten zien
            #region testlist aanmaken

            var testlistProducts = new List<Product>() {

                new Product
                {
                    EAN = "8888888888888",
                    AverageRating = 3,
                    RatingCount = 4,
                    BTWPercentage = 21,
                    CategorieId = 1,
                    //Categorie = new ProductCategorie { Name = "testcat" },
                    CountInStock = 0,
                    ExtraInfo = "dit is een gesmurft produkt",
                    Name = "Smurven",
                    MinStock = 5,
                    MaxStock = 100,
                    RecommendedUnitPrice = 22.5,
                    SolderPrice = 15,
                    
                }  ,              
                new Product
                {
                    EAN = "333333333333333",
                    AverageRating = 2.55,
                    RatingCount = 8,
                    BTWPercentage = 21,
                    CategorieId = 1,
                    //Categorie = new ProductCategorie { Name = "testcat" },
                    CountInStock = 0,
                    ExtraInfo = "dit is een geweldig produkt",
                    Name = "testProduct",
                    MinStock = 5,
                    MaxStock = 100,
                    RecommendedUnitPrice = 22.5,
                    SolderPrice = 15,
                },
                new Product
                {
                    EAN = "44444444444",
                    AverageRating = 3.8,
                    RatingCount = 14,
                    BTWPercentage = 21,
                    CategorieId = 1,
                    //Categorie = new ProductCategorie { Name = "testcat" },
                    CountInStock = 0,
                    ExtraInfo = "dit is een geweldig produkt",
                    Name = "blikje cola",
                    MinStock = 5,
                    MaxStock = 100,
                    RecommendedUnitPrice = 12,
                    SolderPrice = 4.2,
                }
            };

            #endregion


            //model.ProductsToShow = testlistProducts;

            var productsResult = await _repos.Products.GetAllAsync();

            model.ProductsToShow = productsResult.Data.ToList();



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
    }
}
