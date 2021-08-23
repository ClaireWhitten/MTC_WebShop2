
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MTCmodel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.ProductAdmin
{
    public class ProductIndexViewModel
    {
        [Key]
        [MaxLength(13, ErrorMessage = "EAN must be 13 digit characters")]
        public string EAN { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage = "maximum {1} characters allowed for Productame")]
        public string Name { get; set; }


        [Required]
        [Range(0, double.MaxValue)]
        public double RecommendedUnitPrice { get; set; }


        public int CountInStock { get; set; }


        public double? SolderPrice { get; set; }


        public  string[] Suppliers { get; set; }


        [Required(ErrorMessage = "Category cannot be empty")]
        public string CategorieName { get; set; }


        public string ProductImagesrc { get; set; }

    }
}

