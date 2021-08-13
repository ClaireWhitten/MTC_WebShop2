using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTC_WebServerCore.ViewModels.Category;
using MTC_WebServerCore.Models;
using Microsoft.Extensions.Logging;
using MTCrepository.TDSrepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using MTCmodel;

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
        public IActionResult AddCategory([FromForm] AddCategoryViewModel model)
        {
            //save to db here
            if (TryValidateModel(model)){

                ProductCategorie newCategory = new ProductCategorie()
                {
                    Name = model.Name,
                    ParentCategorieID = model.ParentCategorieId
                };

                _repos.ProductCategories.AddAsync(newCategory);


                //return RedirectToAction(nameof(Overview));
            }
            
            return View();
        }



        //Gets an overview of all categories



        //Gets the 'Edit cateogry' view



        //Edits the category in the db




        //Gets the 'delete category' view





        // Deletes the category in the db 


    }
}
