using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.Category
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Name can't be empty")]
        [MaxLength(50)]
        [Display(Name = "Category name:")]
        public string Name { get; set; }


        [Display(Name = "Parent Category:")]
        public int? ParentCategorieId { get; set; }

        public List<SelectListItem> productCategories { get; set; } = new List<SelectListItem>();


        //public IEnumerable<ProductCategorie> ProductCategories { get; set; }


    }
}
