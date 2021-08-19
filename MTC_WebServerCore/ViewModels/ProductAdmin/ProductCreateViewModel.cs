﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.ProductAdmin
{
    public class ProductCreateViewModel
    {
        [Key()]
        [Required(ErrorMessage = "EAN must be 13 digit characters")]
        
        public string EAN { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage = "maximum {1} characters allowed for Productame")]
        [Display(Name="Product name")]
        public string Name { get; set; }

        
        [MaxLength(255, ErrorMessage = "maximum {1} characters allowed for Extra info")]

        [Display(Name = "Description")]
        public string ExtraInfo { get; set; }

        //-------------------------------------------------------------------
        [Required]
        [Range(0, 30, ErrorMessage = "{0} should be between {1} and {2}")]
        [Display(Name = "BTW (%)")]
        public double BTWPercentage { get; set; }




        [Display(Name = "Maximum stock")]
        public int MaxStock { get; set; }
        [Display(Name = "Minimum stock")]

        public int MinStock { get; set; }


        [Required]
        [Range(0, double.MaxValue)]
        [Display(Name = "Recommended Price")]
        public double RecommendedUnitPrice { get; set; }


        [Display(Name = "Solde (%)")]
        public double? SolderPercentage { get; set; }

        [Display(Name = "Product images")]

        public byte[] ProductImages { get; set; }


        [Required(ErrorMessage = "Category cannot be empty")]
        [Display(Name = "Category")]
        public int CategorieId { get; set; }
        //public ProductCategorie Categorie { get; set; }

        [Display(Name = "Suppliers")]
        public List< string> SupplierIds { get; set; }
   //     public Supplier Supplier {get;set;}
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Suppliers { get; set; }

    }
}