using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
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
        
        public async Task<IActionResult> IndexProductAdminAsync()
        {
            TSDreposResultIenumerable<Product> resultProducts = await _repos.Products.GetProductsWithSuppliers();
            IEnumerable<Product> Products = resultProducts.Data.Where(x=>x.IsActive==true);

            TSDreposResultIenumerable<ProductImage> resultProductImages = await _repos.ProductImages.GetAllAsync();
            IEnumerable<ProductImage> ProductImages = resultProductImages.Data;


            if (Products.Count()>0)
            {
                var vm = Products.Select(x => new ProductIndexViewModel
                {
                    EAN = x.EAN,
                    Name = x.Name,
                    RecommendedUnitPrice = x.RecommendedUnitPrice,
                    CountInStock = x.CountInStock,
                    SolderPrice = x.SolderPrice,
                    CategorieName = x.Categorie.Name, 
                    ProductImagesrc = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(x.Images.FirstOrDefault().Image)),
                    Suppliers = x.Suppliers.Select(x=>x.Name).ToArray(),
                });
                List<KeyValuePair<string, string>> Photos = new List<KeyValuePair<string, string>>();
                
                return View(vm);

            }
            return View();
        }
        

        
        public async Task<IActionResult> CreateProductAdmin()
        {
            TSDreposResultIenumerable<ProductCategorie> resultProductCategories = await _repos.ProductCategories.GetAllAsync();
            IEnumerable<ProductCategorie> ProductCategories = resultProductCategories.Data;

            TSDreposResultIenumerable<Supplier> resultSuppliers = await _repos.Suppliers.GetByConditionAsync(s=>s.ApplicationUser.IsActive==true);
            IEnumerable<Supplier> suppliers = resultSuppliers.Data;


            var vm = new ProductCreateViewModel
            {
                Categories = ProductCategories.Select(c => new SelectListItem { Text = c.Name, Value = c.ID.ToString() }),
                Suppliers=suppliers.Select(s=>new SelectListItem { Text=s.Name,Value=s.Id.ToString()})
            };


            
                List<object> treedata = new List<object>();
            foreach (var item in ProductCategories)
            {
                int Id;
                int Pid=0;
                bool Haschild = false;
                string Name;

                Name = item.Name;
                Id = item.ID;
                if (item.SubCategories !=null &&  item.SubCategories.Count!=0)
                {
                    Haschild = true;
                }
                if(item.ParentCategorieID!=0 )
                {
                    Pid =Convert.ToInt32( item.ParentCategorieID);
                }
                treedata.Add(new { 
                    id=Id,
                    name=Name,
                    haschild=Haschild,
                    pid=Pid
                });
            }

                ViewBag.dataSource = treedata;
                
           


            return View(vm);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductAdminAsync([FromForm] ProductCreateViewModel product,List<IFormFile> ProductImages)
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
                newproduct.Suppliers = new List<Supplier>();
                TSDreposResultOneObject<Supplier> resultProductCategorie = await _repos.Suppliers.GetByIdAsync(product.SupplierId);
                newproduct.Suppliers.Add(resultProductCategorie.Data);
                newproduct.Images = new List<ProductImage>();

                
                foreach (var item in Request.Form.Files)
                {
                    ProductImage img = new ProductImage();
                    img.ID = Guid.NewGuid().ToString();
                    
                    MemoryStream ms = new MemoryStream();
                    item.CopyTo(ms);
                    img.Image = ms.ToArray();
                    ms.Close();
                    ms.Dispose();

                    newproduct.Images.Add(img);

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