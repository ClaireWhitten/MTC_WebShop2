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
        [Route("")]
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
                    CategorieName = getcategoryPath( x.Categorie.ID),
                    ProductImagesrc  = x.Images.Count>0 ? string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(x.Images.FirstOrDefault().Image)) : null ,
                    Suppliers = x.Suppliers.Select(x=>x.Name).ToArray(),
                });
                List<SelectListItem> Categories = new List<SelectListItem>();
                var allCategories = (await _repos.ProductCategories.GetAllAsync()).Data;

                //for each product cateogry get parent path
                foreach (var productCategory in allCategories)
                {
                    var parentCategories = await _repos.ProductCategories.GetAllParents(productCategory.ID);
                    string parentPath = "";
                    foreach (var parentCategory in parentCategories)
                    {
                        parentPath += ">" + parentCategory.Name;
                    }
                    //set the path as the text in the select list
                    Categories.Add(new SelectListItem { Text = parentPath, Value = productCategory.ID.ToString() });

                }
                ViewBag.Categories = Categories;
                return View(vm);

            }
            return View();
        }
        
        public  string getcategoryPath(int id)
        {
            var parentCategories =  _repos.ProductCategories.GetAllParents(id);
            string parentPath = "";
            foreach (var parentCategory in parentCategories.Result)
            {
                parentPath += ">" + parentCategory.Name;
            }
            return parentPath;
        }
        
        public async Task<IActionResult> CreateProductAdmin()
        {
            TSDreposResultIenumerable<ProductCategorie> resultProductCategories = await _repos.ProductCategories.GetAllAsync();
            IEnumerable<ProductCategorie> ProductCategories = resultProductCategories.Data;

            TSDreposResultIenumerable<Supplier> resultSuppliers = await _repos.Suppliers.GetByConditionAsync(s=>s.ApplicationUser.IsActive==true);
            IEnumerable<Supplier> suppliers = resultSuppliers.Data;


            var vm = new ProductCreateViewModel
            {
                //Categories = ProductCategories.Select(c => new SelectListItem { Text = c.Name, Value = c.ID.ToString() }),
                Suppliers=suppliers.Select(s=>new SelectListItem { Text=s.Name,Value=s.Id.ToString()}).ToList()
            };

            vm.Categories = new List<SelectListItem>();
            var allCategories = (await _repos.ProductCategories.GetAllAsync()).Data;
            foreach (var productCategory in allCategories)
                vm.Categories.Add(new SelectListItem { Text = getcategoryPath(productCategory.ID), Value = productCategory.ID.ToString() });

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
                    MaxStock = product.MaxStock,
                    MinStock = product.MinStock,
                    RecommendedUnitPrice = product.RecommendedUnitPrice,
                    CategorieId = product.CategorieId,
                    
                    SolderPrice = product.SolderPercentage
                };
                //newproduct.Suppliers = new List<Supplier>();
                //TSDreposResultOneObject<Supplier> resultProductCategorie = await _repos.Suppliers.GetByIdAsync(product.SupplierId);
                //newproduct.Suppliers.Add(resultProductCategorie.Data);
                newproduct.Images = new List<ProductImage>();
                newproduct.Suppliers = new List<Supplier>();
                foreach (var item in product.SupplierIds)
                {
                    newproduct.Suppliers.Add((await _repos.Suppliers.GetByIdAsync(item)).Data);
                }


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


        [HttpGet]
        public async Task<IActionResult> DetailProductAdmin([FromRoute]string id)
        {
            Product product = (await _repos.Products.GetByIdAsync(id)).Data;
            var vm = new ProductDetailViewModel
            {
                Product=product,
                CategoryName= getcategoryPath(product.CategorieId),
            };
            if(product.Images.Count>0)
            {
                vm.ProductImages = new List<string>();
                foreach (var item in product.Images)
                vm.ProductImages.Add(string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Image)));
            }
            
            return View(vm);
        }




        [HttpGet]
        public async Task<IActionResult> EditProductAdmin([FromRoute] string id)
        {
            TSDreposResultIenumerable<ProductCategorie> resultProductCategories = await _repos.ProductCategories.GetAllAsync();
            IEnumerable<ProductCategorie> ProductCategories = resultProductCategories.Data;

            TSDreposResultIenumerable<Supplier> resultSuppliers = await _repos.Suppliers.GetByConditionAsync(s => s.ApplicationUser.IsActive == true);
            IEnumerable<Supplier> suppliers = resultSuppliers.Data;


            Product product = (await _repos.Products.GetByIdAsync(id)).Data;
            var vm = new ProductEditViewModel
            {
                Product = product,
                Suppliers = suppliers.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() }).ToList()
                
            };
            vm.ProductImages = new List<string>();
            foreach (var item in product.Images)
            {
                vm.ProductImages.Add(string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Image)));

            }
            vm.SupplierIds = new List<string>();
            foreach (var item in product.Suppliers)
            {
                vm.SupplierIds.Add(item.Id);
            }   

        vm.Categories = new List<SelectListItem>();
            var allCategories = (await _repos.ProductCategories.GetAllAsync()).Data;
            foreach (var productCategory in allCategories)
                vm.Categories.Add(new SelectListItem { Text = getcategoryPath(productCategory.ID), Value = productCategory.ID.ToString()});
            return View(vm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProductAdminAsync([FromForm] ProductEditViewModel oldproduct, List<IFormFile> ProductImages)
        {

            if (TryValidateModel(oldproduct))
            {
                var newproduct = new Product
                {
                    EAN = oldproduct.Product.EAN,
                    IsActive = true,
                    Name = oldproduct.Product.Name,
                    ExtraInfo = oldproduct.Product.ExtraInfo,
                    BTWPercentage = oldproduct.Product.BTWPercentage,
                    MaxStock = oldproduct.Product.MaxStock,
                    MinStock = oldproduct.Product.MinStock,
                    RecommendedUnitPrice = oldproduct.Product.RecommendedUnitPrice,
                    CategorieId = oldproduct.Product.CategorieId,

                    SolderPrice = oldproduct.Product.SolderPrice
                };
                
                
               

                newproduct.Suppliers = new List<Supplier>();
                foreach (var item in oldproduct.SupplierIds)
                {
                    newproduct.Suppliers.Add((await _repos.Suppliers.GetByIdAsync(item)).Data);
                }
                
                    await _repos.ProductImages.RemoveByCondition(i=>i.ProductEAN==oldproduct.Product.EAN);
               
                //newproduct.Images = new List<ProductImage>();
                foreach (var item in Request.Form.Files)
                {
                    ProductImage img = new ProductImage();
                    img.ID = Guid.NewGuid().ToString();
                    img.ProductEAN = newproduct.EAN;
                    img.Product = newproduct;
                    MemoryStream ms = new MemoryStream();
                    item.CopyTo(ms);
                    img.Image = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                    await _repos.ProductImages.AddAsync(img);
                    //newproduct.Images.Add(img);

                }
                var p= (await _repos.Products.GetByIdAsync(oldproduct.Product.EAN)).Data;
                p.EAN = newproduct.EAN;
                p.Name = newproduct.Name;
                p.ExtraInfo = newproduct.ExtraInfo;
                p.RecommendedUnitPrice = newproduct.RecommendedUnitPrice;
                p.SolderPrice = newproduct.SolderPrice;
                p.BTWPercentage = newproduct.BTWPercentage;
                p.MinStock = newproduct.MinStock;
                p.MaxStock = newproduct.MaxStock;
                p.CategorieId = newproduct.CategorieId;
                //p.Images = null;
                //p.Images = newproduct.Images;
                p.Suppliers = newproduct.Suppliers;
                p.CountInStock = newproduct.CountInStock;
                p.Categorie = (await _repos.ProductCategories.GetByIdAsync(newproduct.CategorieId)).Data;

                await _repos.Products.UpdateAsync(p);

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