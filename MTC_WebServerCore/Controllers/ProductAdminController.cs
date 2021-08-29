using Microsoft.AspNetCore.Authorization;
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MTC_WebServerCore.Controllers
{
    [Authorize(Roles = "SuperAdmin,Administration")]

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


        
        //=================== Admin Products overview
        public async Task<IActionResult> IndexProductAdminAsync(int CategoryId,string SearchTerm)
        {
            TSDreposResultIenumerable<Product> resultProducts = await _repos.Products.GetProductsWithSuppliers();

            IEnumerable<Product> products = resultProducts.Data;
            var Products = products.Where(x => x.IsActive == true).ToList();
            List<SelectListItem> Categories=new List<SelectListItem>();
            Categories.AddRange((await _repos.ProductCategories.GetAllPosiblePaths()).Select(x => new SelectListItem { Text = x.Value, Value = x.Key.ToString() }));



            if (Products.Count()>0)
            {
                if (!string.IsNullOrEmpty(SearchTerm))
                {
                    Products = Products.Where(s => s.Name.Contains(SearchTerm)).ToList();
                }

                if (CategoryId!=0)
                {
                    Products = Products.Where(x =>_repos.ProductCategories.GetAllSubCats(CategoryId).Select(c=>c.ID).Contains(x.CategorieId)|| x.CategorieId==CategoryId).ToList();
                    
                }

                var vm = new ListIndexProductAdmin();
                 vm.Products = Products.Select(x => new ProductIndexViewModel
                {
                    EAN = x.EAN,
                    Name = x.Name,
                    RecommendedUnitPrice = x.RecommendedUnitPrice,
                    CountInStock = x.CountInStock,
                    SolderPrice = x.SolderPrice,
                    CategorieName = Categories.FirstOrDefault(c=>Convert.ToInt32( c.Value)==x.CategorieId).Text,

                    ProductImagesrc  = x.Images.Count>0 ? string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(x.Images.FirstOrDefault().Image)) : null ,
                    Suppliers = x.Suppliers.Select(x=>x.Name).ToArray(),
                });
                vm.Categories = Categories;

                return View(vm);

            }
            return View();
        }
        
        //================= add product view
        public async Task<IActionResult> CreateProductAdmin()
        {

            TSDreposResultIenumerable<Supplier> resultSuppliers = await _repos.Suppliers.GetByConditionAsync(s => s.ApplicationUser.IsActive == true);
            IEnumerable<Supplier> suppliers = resultSuppliers.Data;

            ViewBag.Suppliers = suppliers.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() }).ToList();

            List<SelectListItem> Categories = new List<SelectListItem>();
            Categories.AddRange((await _repos.ProductCategories.GetAllPosiblePaths()).Select(x => new SelectListItem { Text = x.Value, Value = x.Key.ToString() }));
            ViewBag.Categories = Categories;

            return View();
        }



        //======================= Add Product 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductAdminAsync([FromForm] ProductCreateViewModel product, List<IFormFile> ProductImages)
        {

            Regex reg = new Regex(@"^[1-9]\\d*(\\.\\d+)?$");


            if (product.MinStock < 0)
                ModelState.AddModelError(string.Empty, "Minimum stock most be equal to, or greater than 0.");
            if (product.MaxStock < product.MinStock)
                ModelState.AddModelError(string.Empty, "Maximum stock cannot be less than Minimum stock.");

            if(reg.IsMatch( product.RecommendedUnitPrice))
                ModelState.AddModelError(string.Empty, "Recomended price must be a number and greater than 0.");

           

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
                    RecommendedUnitPrice = double.Parse(product.RecommendedUnitPrice, CultureInfo.InvariantCulture),
                    //RecommendedUnitPrice = Convert.ToDouble(product.RecommendedUnitPrice.Replace('.', ',')),
                    CategorieId = product.CategorieId,
                    SolderPrice = product.SolderPercentage
                };
                newproduct.Images = new List<ProductImage>();
                newproduct.Suppliers = new List<Supplier>();
                foreach (var item in product.SupplierIds)
                    newproduct.Suppliers.Add((await _repos.Suppliers.GetByIdAsync(item)).Data);
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


            TSDreposResultIenumerable<Supplier> resultSuppliers = await _repos.Suppliers.GetByConditionAsync(s => s.ApplicationUser.IsActive == true);
            IEnumerable<Supplier> suppliers = resultSuppliers.Data;

            ViewBag.Suppliers = suppliers.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() }).ToList();

            List<SelectListItem> Categories = new List<SelectListItem>();
            Categories.AddRange((await _repos.ProductCategories.GetAllPosiblePaths()).Select(x => new SelectListItem { Text = x.Value, Value = x.Key.ToString() }));

            ViewBag.Categories = Categories;

            return View();
        }

        //========================== Product Details
        [HttpGet]
        public async Task<IActionResult> DetailProductAdmin([FromRoute] string id)
        {
            List<SelectListItem> Categories = new List<SelectListItem>();
            Categories.AddRange((await _repos.ProductCategories.GetAllPosiblePaths()).Select(x => new SelectListItem { Text = x.Value, Value = x.Key.ToString() }));

            Product product = (await _repos.Products.GetByIdAsync(id)).Data;
            var vm = new ProductDetailViewModel
            {
                Product=product,
                CategoryName = Categories[product.CategorieId].Text,
            };
            if (product.Images.Count > 0)
            {
                vm.ProductImages = new List<string>();
                foreach (var item in product.Images)
                    vm.ProductImages.Add(string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Image)));
            }

            return View(vm);
        }



        //=========================== Product Edit View
        [HttpGet]
        public async Task<IActionResult> EditProductAdmin([FromRoute] string id)
        {

            TSDreposResultIenumerable<Supplier> resultSuppliers = await _repos.Suppliers.GetByConditionAsync(s => s.ApplicationUser.IsActive == true);
            IEnumerable<Supplier> suppliers = resultSuppliers.Data;


            Product product = (await _repos.Products.GetByIdAsync(id)).Data;
            var vm = new ProductEditViewModel
            {
                EAN = product.EAN,
                Name=product.Name,
                ExtraInfo=product.ExtraInfo,
                RecommendedUnitPrice=product.RecommendedUnitPrice.ToString().Replace(',', '.'),
                SolderPercentage=product.SolderPrice,
                MaxStock=product.MaxStock,
                MinStock=product.MaxStock,
                CategorieId=product.CategorieId,
                BTWPercentage=product.BTWPercentage,
                SupplierIds=product.Suppliers.Select(x=>x.Id).ToList(),
                Suppliers = suppliers.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() }).ToList()
            };



            List<SelectListItem> Categories = new List<SelectListItem>();
            Categories.AddRange((await _repos.ProductCategories.GetAllPosiblePaths()).Select(x => new SelectListItem { Text = x.Value, Value = x.Key.ToString() }));

            ViewBag.Categories = Categories;

            List<string> ProductImages = new List<string>();
            foreach (var item in product.Images)
                ProductImages.Add(string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Image)));
            ViewBag.ProductImages = ProductImages;
            return View(vm);
        }


        //========================== Edit Product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProductAdminAsync([FromForm] ProductEditViewModel oldproduct, List<IFormFile> ProductImages)
        {

            Regex reg = new Regex(@"^[1-9]\\d*(\\.\\d+)?$");
            if (reg.IsMatch(oldproduct.RecommendedUnitPrice))
                ModelState.AddModelError(string.Empty, "Recomended price must be a number and greater than 0.");

            if (oldproduct.MinStock < 0)
                ModelState.AddModelError(string.Empty, "Minimum stock most be greater than 0.");
            if (oldproduct.MaxStock < oldproduct.MinStock)
                ModelState.AddModelError(string.Empty, "Maximum stock cannot be less than Minimum stock.");
            if (TryValidateModel(oldproduct))
            {
                var newproduct = new Product
                {
                    EAN = oldproduct.EAN,
                    IsActive = true,
                    Name = oldproduct.Name,
                    ExtraInfo = oldproduct.ExtraInfo,
                    BTWPercentage = oldproduct.BTWPercentage,
                    MaxStock = oldproduct.MaxStock,
                    MinStock = oldproduct.MinStock,
                    RecommendedUnitPrice = double.Parse(oldproduct.RecommendedUnitPrice, CultureInfo.InvariantCulture),
                    //RecommendedUnitPrice = Convert.ToDouble(oldproduct.RecommendedUnitPrice.Replace('.', ',')),
                    CategorieId = oldproduct.CategorieId,
                    SolderPrice = oldproduct.SolderPercentage
                };
                
                newproduct.Suppliers = new List<Supplier>();
                foreach (var item in oldproduct.SupplierIds)
                    newproduct.Suppliers.Add((await _repos.Suppliers.GetByIdAsync(item)).Data);
                await _repos.ProductImages.RemoveByCondition(i=>i.ProductEAN==oldproduct.EAN);
               

                newproduct.Images = new List<ProductImage>();
                foreach (var item in Request.Form.Files)
                {
                    ProductImage img = new ProductImage();
                    img.ID = Guid.NewGuid().ToString();
                    img.ProductEAN = newproduct.EAN;
                    MemoryStream ms = new MemoryStream();
                    item.CopyTo(ms);
                    img.Image = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                    newproduct.Images.Add(img);

                }

                var p= (await _repos.Products.GetByIdAsync(oldproduct.EAN)).Data;

                p.EAN = newproduct.EAN;
                p.Name = newproduct.Name;
                p.ExtraInfo = newproduct.ExtraInfo;
                p.RecommendedUnitPrice = newproduct.RecommendedUnitPrice;
                p.SolderPrice = newproduct.SolderPrice;
                p.BTWPercentage = newproduct.BTWPercentage;
                p.MinStock = newproduct.MinStock;
                p.MaxStock = newproduct.MaxStock;
                p.CategorieId = newproduct.CategorieId;
                p.Images = newproduct.Images;
                p.Suppliers = newproduct.Suppliers;
                p.CountInStock = newproduct.CountInStock;
                p.Categorie = (await _repos.ProductCategories.GetByIdAsync(newproduct.CategorieId)).Data;

                await _repos.Products.UpdateAsync(p);

                return RedirectToAction("IndexProductAdmin");
            }

            TSDreposResultIenumerable<Supplier> resultSuppliers = await _repos.Suppliers.GetByConditionAsync(s => s.ApplicationUser.IsActive == true);
            IEnumerable<Supplier> suppliers = resultSuppliers.Data;

            ViewBag.Suppliers = suppliers.Select(s => new SelectListItem { Text = s.Name, Value = s.Id.ToString() }).ToList();


            List<SelectListItem> Categories = new List<SelectListItem>();
            Categories.AddRange((await _repos.ProductCategories.GetAllPosiblePaths()).Select(x => new SelectListItem { Text = x.Value, Value = x.Key.ToString() }));


            ViewBag.Categories = Categories;

            Product pr = (await _repos.Products.GetByIdAsync(oldproduct.EAN)).Data;
            List<string> Images = new List<string>();
            foreach (var item in pr.Images)
                Images.Add(string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.Image)));
            ViewBag.ProductImages = Images;
            return View();
        }


        //===================== Delete Product
        [HttpPost]
        public async Task<IActionResult> DeleteProductAdmin([FromRoute] string id)
        {
            var selectedProduct = (await _repos.Products.GetByIdAsync(id)).Data;

            if (selectedProduct!=null)

            {
                var deleteProduct = await _repos.Products.RemoveAsync(selectedProduct);
                return RedirectToAction("IndexProductAdmin");
            }
            else
                return View();
        }
    }

}

