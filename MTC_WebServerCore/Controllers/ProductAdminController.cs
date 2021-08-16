using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MTC_WebServerCore.ViewModels.Product;
using MTC_WebServerCore.ViewModels.ProductAdmin;
using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.Controllers
{
    public class ProductAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationRepository _repos;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductAdminController(ILogger<HomeController> logger, IApplicationRepository appRepos, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _repos = appRepos;
            _userManager = userManager;
        }
        [Route("")]
        public async Task<IActionResult> IndexProductAdminAsync()
        {
            TSDreposResultIenumerable<Product> resultProducts = await _repos.Products.GetByConditionAsync(p => p.IsActive == true);
            IEnumerable<Product> Products = resultProducts.Data;
            TSDreposResultIenumerable<ProductCategorie> resultProductCategoriess = await _repos.ProductCategories.GetByConditionAsync(p => p.SubCategories.Count == 0);
            IEnumerable<ProductCategorie> ProductCategories = resultProductCategoriess.Data;
            if(Products.Count()>0)
            { 
            var vm = Products.Select(x => new ProductIndexViewModel
            {
                EAN = x.EAN,
                Name = x.Name,
                RecommendedUnitPrice = x.RecommendedUnitPrice,
                CountInStock = x.CountInStock,
                SolderPrice = x.SolderPrice,
                CategorieName = ProductCategories.FirstOrDefault(c=>c.ID==x.CategorieId).Name,
                ProductImage = x.Images.First().Image,
                Supplier=x.Suppliers.First()
                
                //ProductImage =new FormFile(new MemoryStream(x.Images.First().Image), 0, x.Images.First().Image.Length, "name", "fileName") ,
            });
            
                return View(vm);
            }
            return View();
        }

        
        public async Task<IActionResult> CreateProductAdmin()
        {
            TSDreposResultIenumerable<ProductCategorie> resultProductCategoriess = await _repos.ProductCategories.GetByConditionAsync(p => p.SubCategories.Count == 0);
            IEnumerable<ProductCategorie> ProductCategories = resultProductCategoriess.Data;

            TSDreposResultIenumerable<Supplier> resultSuppliers = await _repos.Suppliers.GetByConditionAsync(s=>s.IsActive==true);
            IEnumerable<Supplier> suppliers = resultSuppliers.Data;


            var vm = new ProductCreateViewModel
            {
                Categories = ProductCategories.Select(c => new SelectListItem { Text = c.Name, Value = c.ID.ToString() }),
                Suppliers=suppliers.Select(s=>new SelectListItem { Text=s.Name,Value=s.Id.ToString()})
            };
            return View(vm);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductAdminAsync([FromForm] ProductCreateViewModel product)
        {
            if (TryValidateModel(product))
            {
                var newproduct = new Product
                {
                    EAN = product.EAN,
                    IsActive = true,
                    Name = product.Name,
                    ExtraInfo = product.ExtraInfo,
                    BTWPercentage = product.BTWPercentage,
                    CountInStock = product.CountInStock,
                    MaxStock = product.MaxStock,
                    MinStock = product.MinStock,
                    RecommendedUnitPrice = product.RecommendedUnitPrice,
                    CategorieId = product.CategorieId,
                   
                    SolderPrice = product.SolderPercentage
                };

                TSDreposResultOneObject<Supplier> resultProductCategorie = await _repos.Suppliers.GetByIdAsync(product.SupplierId);
                newproduct.Suppliers.Add(resultProductCategorie.Data);
                newproduct.Images = new List<ProductImage>();
                string id ="0" ;
                int cnt = 0;
                foreach (var item in product.IImages)
                {
                    if (item.Length > 0)
                    {
                        using (var reader = new StreamReader(item.OpenReadStream()))
                        {
                            string contentAsString = reader.ReadToEnd();
                            ProductImage photo = new ProductImage { Image = new byte[contentAsString.Length * sizeof(char)], ProductEAN = newproduct.EAN,ID=(Convert.ToInt32( id )+cnt++).ToString()} ;
                            await _repos.ProductImages.AddAsync(photo);
                            //newproduct.Images.Add(photo);
                        }
                    }
                }
                await _repos.Products.AddAsync(newproduct);
                return RedirectToAction("IndexProductAdmin");
            }

                return View();
        }
    }
}
//var
//    TSDreposResultIenumerable<Product> resultProducts = await _repos.Products.GetByConditionAsync(p => p.CategorieId == categoryId);

//    //Make into viewModel instead
//    IEnumerable<Product> allCategoryProducts = resultProducts.Data;