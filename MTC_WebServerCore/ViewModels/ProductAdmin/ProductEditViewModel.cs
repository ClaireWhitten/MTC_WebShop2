using Microsoft.AspNetCore.Mvc.Rendering;
using MTCmodel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.ProductAdmin
{
    public class ProductEditViewModel
    {
        public Product Product { get; set; }
        //public ProductCategorie Categorie { get; set; }

        [Display(Name = "Suppliers")]
        public List<string> SupplierIds { get; set; }
        //     public Supplier Supplier {get;set;}
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Suppliers { get; set; }

        public List<string> ProductImages { get; set; }
    }
}
