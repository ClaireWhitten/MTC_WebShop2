using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MTC_WebServerCore.Models;
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
        public async Task<IActionResult> IndexAsync()
        {





            //ProductCategorie testCategorie = new ProductCategorie
            //{
            //    Name = "Elektronica"
            //};
            //var testCategegoryAdded = await _repos.ProductCategories.AddAsync(testCategorie);


            //ProductCategorie testCategorie2 = new ProductCategorie
            //{
            //    Name = "TV",
            //    ParentCategorieID = 1,
            //};
            //var testCategegoryAdded2 = await _repos.ProductCategories.AddAsync(testCategorie2);



            //if (testCategegoryAdded2.ErrorCode != TDSreposErrCode.OK)
            //{
            //    _logger.LogError(testCategegoryAdded2.ErrorCode.ToString());
            //}

            //if (testCategegoryAdded.ErrorCode != TDSreposErrCode.OK)
            //{
            //    _logger.LogError(testCategegoryAdded.ErrorCode.ToString());
            //}

            //if(testCategegoryAdded.ErrorCode == TDSreposErrCode.OK)


            //TestModel testModel = new TestModel { Name = "dit is een test" };
            //await _repos.TestModel.AddAsync(testModel);


            //Product testProduct = new Product
            //{
            //    EAN = "8888888888888",
            //    AverageRating = 3,
            //    BTWPercentage = 21,
            //    CategorieId = 1,
            //    //Categorie = new ProductCategorie { Name = "testcat" },
            //    CountInStock = 0,
            //    ExtraInfo = "dit is een geweldig produkt",
            //    Name = "testProduct",
            //    MinStock = 5,
            //    MaxStock = 100,
            //    RecommendedUnitPrice = 22.5,


            //};

            //var testProductReview = new ProductReview()
            //{
            //    Comment = "hahahahaha",
            //    DateTime = DateTime.Now,
            //    ProductEAN = "4444444444444",
            //    Rating = 1,
            //    UserId = "1sfsdfsfd",

            //};

            //var resultProductView = await _repos.ProductReviews.AddAsync(testProductReview);

            //var resultAdd = await _repos.Products.AddAsync(testProduct);


            //if(resultAdd.ErrorCode != TDSreposErrCode.OK)
            //{
            //    _logger.LogError(resultAdd.ErrorCode.ToString());
            //}

            //var resultUpdate = await _repos.Products.UpdateAsync(testProduct);


            //var result = await _repos.Products.GetAllAsync();

            //var model = result.Data;
            IEnumerable<Product> model = null;

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
