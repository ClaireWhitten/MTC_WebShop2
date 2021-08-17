using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MTC_WebServerCore.ViewModels.Category;
using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MTC_WebServerCore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IApplicationRepository _repos;

        public CategoryController(ILogger<CategoryController> logger, IApplicationRepository appRepos)
        {
            _logger = logger;
            _repos = appRepos;
        }


        //Gets 'add category' view
        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            //Get all product categories
            var result = await _repos.ProductCategories.GetAllAsync();
            var productCategories = result.Data;
            AddCategoryViewModel vm = new AddCategoryViewModel();
          
           //for each product cateogry find its parents and create a path
            foreach (var productCategory in productCategories)
            {
                var parentCategories = await _repos.ProductCategories.GetAllParents(productCategory.ID);
                string parentPath = "";
                foreach (var parentCategory in parentCategories)
                {
                    parentPath += ">" + parentCategory.Name;
                }
                //set the path as the text in the select list
                vm.productCategories.Add(new SelectListItem { Text = parentPath, Value = productCategory.ID.ToString() });
                
            }

            return View(vm);
        }




        //Adds the new category to db
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm] AddCategoryViewModel model)
        {
            //if it's a parent category, checks if it already exists is db 
            bool duplicateExists = false;
            if (model.ParentCategorieId == null)
            {
                var duplicateCheck = await _repos.ProductCategories.GetSingleOrDefaultAsync(x => x.Name == model.Name && x.ParentCategorieID == null);
                var duplicate = duplicateCheck.Data;
                if (duplicate != null)
                {
                    duplicateExists = true;
                }
            }
            //if model state is valid and no duplicate exists adds the new category and redirects to overview
            if (ModelState.IsValid && !duplicateExists)
            {
  
                ProductCategorie newCategory = new ProductCategorie()
                {
                    Name = model.Name,
                    ParentCategorieID = model.ParentCategorieId
                };

                var result = await _repos.ProductCategories.AddAsync(newCategory);
                return RedirectToAction(nameof(OverviewCategories));
                
            }

            var productsResult = await _repos.ProductCategories.GetAllAsync();
            var productCategories = productsResult.Data;
            foreach (var productCategory in productCategories)
            {
                model.productCategories.Add(new SelectListItem { Text = productCategory.Name, Value = productCategory.ID.ToString() });

            }

            return View(model);
        }




       //Shows overview of categories
        [HttpGet]
        public async Task<IActionResult> OverviewCategories()
        {
            //get all existing categories
            var allCategories = await _repos.ProductCategories.GetCategoriesWithSubandParent();
            var vm = allCategories.Data.Select(x => new OverviewCategoriesViewModel()
            {
                Id = x.ID,
                Products = x.Products,
                Subcategories = x.SubCategories,
                Name = x.Name,
                ParentCategorie = x.ParentCategorie

            }).ToList(); // to list needed to set the parentPath property in foreach


            foreach (var cat in vm)
            {
                var parents = (await _repos.ProductCategories.GetAllParents(cat.Id)).ToList();

                string parentPath = "";
                for (var i = 0; i < parents.Count(); i++)
                {
                 
                    parentPath += ">" + parents[i].Name;

                }
                cat.ParentPath = parentPath;  
            }
            return View(vm);
        }

        


        //Gets the 'Edit cateogry' view
        public async Task<IActionResult> EditCategory([FromRoute] int id)
        {
            //Get selected category
            var selectedCat = (await _repos.ProductCategories.GetByIdAsync(id)).Data;

            //Get the current parent path of the selected category
            var currentParents = await _repos.ProductCategories.GetAllParents(selectedCat.ID);
            string currentParentPath = string.Join(">", currentParents.Select(p => p.Name));

            //Create the vm
            EditCategoryViewModel vm = new EditCategoryViewModel()
            {
                Name = selectedCat.Name,
                CurrentParents = currentParentPath
            };

            //Get all product categories 
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
                vm.productCategories.Add(new SelectListItem { Text = parentPath, Value = productCategory.ID.ToString() });

            }

            return View(vm);
        }
        

        //Edits the category in the db




        //Gets the 'delete category' view
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var categoryResult = await _repos.ProductCategories.GetByIdAsync(id);
            var selectedCategory = categoryResult.Data;
            return View(selectedCategory); 
        }


       [HttpPost]
       public async Task<IActionResult> DeleteConfirm([FromRoute] int id)
       {
            var categoryResult = await _repos.ProductCategories.GetByIdAsync(id);
            var selectedCategory = categoryResult.Data;
            var deleteResult = await _repos.ProductCategories.RemoveAsync(selectedCategory);
            return RedirectToAction(nameof(OverviewCategories));
       }

        


    }
}


