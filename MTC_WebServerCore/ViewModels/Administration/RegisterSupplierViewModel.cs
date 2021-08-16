using Microsoft.AspNetCore.Mvc;
using MTC_WebServerCore.ViewModels.Account;
using MTCmodel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.Administration
{
    public class RegisterSupplierViewModel 
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }



        public Supplier Supplier { get; set; }


        //public Address Address { get; set; }
    }
}
