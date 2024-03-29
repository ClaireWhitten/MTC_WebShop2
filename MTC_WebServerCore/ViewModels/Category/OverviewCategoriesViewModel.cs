﻿using MTCmodel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.Category
{
    public class OverviewCategoriesViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name can't be empty")]
        [MaxLength(50)]
        [Display(Name = "Category name:")]
        public string Name { get; set; }


        public string FullPath { get; set; }


        public IEnumerable<ProductCategorie> Subcategories { get; set; } = new List<ProductCategorie>();








    }
}
