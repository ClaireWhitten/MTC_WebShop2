using Microsoft.AspNetCore.Mvc;
using MTCmodel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.Account
{
    public class RegisterClientViewModel : _RegisterViewModel
    {
        public Client Client { get; set; }

        [Required]
        public Address Address { get; set; }
    }
}
