using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Administrator,SuperAdmin")]
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

            AddCategoryViewModel vm = new AddCategoryViewModel();
            var catDictionary = await _repos.ProductCategories.GetAllPosiblePaths();

           //for each product cateogry find its parents and create a path
            foreach (var category in catDictionary)
            {
                
                //set the path as the text in the select list
                vm.productCategories.Add(new SelectListItem { Text = category.Value, Value = category.Key.ToString() });
                
            }

            return View(vm);
        }




        //Adds the new category to db
        [ValidateAntiForgeryToken]
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
            var categoryModels = allCategories.Data.Select(x => new OverviewCategoriesViewModel()
            {
                Id = x.ID,
                Name = x.Name,
                Subcategories = x.SubCategories,
                
            }).ToList(); 

            var catDictionary = await _repos.ProductCategories.GetAllPosiblePaths();


            foreach (var cat in categoryModels)
            {
                cat.FullPath = catDictionary.FirstOrDefault(d=>d.Key == cat.Id).Value;  
            }
            return View(categoryModels);
        }

        





        //Gets details of category 
        [HttpGet]
        public async Task<IActionResult> DetailCategory([FromRoute] int id)
        {
            var result = await _repos.ProductCategories.GetCategoryWithAll(id);
            if (result.Data != null)
            {
                var cat = result.Data;
                return View(cat);
            }
            else
            {
                return RedirectToAction(nameof(NotFoundError));
            }
        }






        //Gets the 'Edit cateogry' view and sets current details of the category
        [HttpGet]
        public async Task<IActionResult> EditCategory([FromRoute] int id)
        {
            //Get selected category
            var selectedCat = (await _repos.ProductCategories.GetByIdAsync(id)).Data;

            //Get path of the category it belongs to (parent)
            var catDictionary = await _repos.ProductCategories.GetAllPosiblePaths();
            var belongsTo = catDictionary.FirstOrDefault(x => x.Key == selectedCat.ParentCategorieID).Value;


            //Create the vm
            EditCategoryViewModel vm = new EditCategoryViewModel()
            {
                Name = selectedCat.Name,
                CurrentLocation = belongsTo
            };

            //Set options for change parent selectlist 

            //get all subcategories of selected category
            var subcats = _repos.ProductCategories.GetAllSubCats(id);
            //remove the subcategories and the selected category from from the dictionary
            foreach (var sub in subcats)
            {
                catDictionary.Remove(sub.ID);
            }
            catDictionary.Remove(id);

            foreach (var cat in catDictionary)
            {
                vm.productCategories.Add(new SelectListItem { Text = cat.Value, Value = cat.Key.ToString() });
            }
    
           
            //set current parent in drop down list
            if (selectedCat.ParentCategorieID == null)
            {
                ViewData["NoParent"] = true;
            }
            else
            {
                ViewData["NoParent"] = false;
                var selected = vm.productCategories.FirstOrDefault(c => c.Value == selectedCat.ParentCategorieID.ToString());
                selected.Selected = true;
            }

            return View(vm);
        }




        //Edits the category in the db
        [ValidateAntiForgeryToken]
        [HttpPost]

        public async Task<IActionResult> EditCategory([FromForm] EditCategoryViewModel model, [FromRoute] int id)
        {

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
                var result = await _repos.ProductCategories.GetByIdAsync(id); 

                if (result.Succeeded)
                {
                    var existingCategory = result.Data;
                    existingCategory.Name = model.Name;
                    existingCategory.ParentCategorieID = model.ParentCategorieId;
                    var updateResult = await _repos.ProductCategories.UpdateAsync(existingCategory);
                    //if the unique key/combination already exists
                    if (!updateResult.Succeeded)
                    {
                        return RedirectToAction(nameof(AddEditError)); 
                    }
                }

                return RedirectToAction(nameof(OverviewCategories));
            }

            return RedirectToAction(nameof(AddEditError)); 
            //var productsResult = await _repos.ProductCategories.GetAllAsync();
            //var productCategories = productsResult.Data;
            //foreach (var productCategory in productCategories)
            //{
            //    model.productCategories.Add(new SelectListItem { Text = productCategory.Name, Value = productCategory.ID.ToString() });

            //}

            //return View(model);
        }
















        //Deletes the category 
        [ValidateAntiForgeryToken]
        [HttpPost]
       public async Task<IActionResult> DeleteCategory([FromRoute] int id)
       {
            var selectedCategory = (await _repos.ProductCategories.GetByIdAsync(id)).Data;
            var deleteCheck = CanBeDeleted(id);
            if (deleteCheck.Result)
            {
                //delete its subcategories
                var subs = _repos.ProductCategories.GetAllSubCats(id);
                foreach (var item in subs)
                {
                    await _repos.ProductCategories.RemoveAsync(item);
                }
                //await _repos.ProductCategories.RemoveRangeAsync(subs);
               
                //delete the category itself
                var deleteCategory = await _repos.ProductCategories.RemoveAsync(selectedCategory);
                return RedirectToAction(nameof(OverviewCategories));
            }
            else
            {
                return RedirectToAction(nameof(DeleteError));
            }
            
        }









        //method checks 
        public async Task<bool> CanBeDeleted(int id)
        {
            var category = (await _repos.ProductCategories.GetCategoryWithProducts(id)).Data;
            var subcats = _repos.ProductCategories.GetAllSubCats(id);
            
            foreach (var sub in subcats)
            {
                if (sub.Products.Count() != 0)
                {
                    return false;
                }
            }

            if (category.Products.Count() != 0)
            {
                return false;
            }

            return true;
        }

        //feedback to user 
        [HttpGet]
        public IActionResult DeleteError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEditError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NotFoundError()
        {
            return View();
        }
    }
}





