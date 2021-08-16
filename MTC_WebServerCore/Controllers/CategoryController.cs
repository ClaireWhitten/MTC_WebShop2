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
            var result = await _repos.ProductCategories.GetAllAsync();
            var productCategories = result.Data;
            AddCategoryViewModel vm = new AddCategoryViewModel();
            //vm.ProductCategories = productcategories.Data;

            foreach (var productCategory in productCategories)
            {
                vm.productCategories.Add(new SelectListItem { Text = productCategory.Name, Value = productCategory.ID.ToString() });
               
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



        //Gets an overview of all categories
        [HttpGet]
        public async Task<IActionResult> OverviewCategories()
        {
            var productsResult = await _repos.ProductCategories.GetCategoriesWithSubandParent();
            var productCategories = productsResult.Data;
            return View(productCategories);
        }


        //Gets the 'Edit cateogry' view



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

        // Deletes the category in the db 


    }
}


