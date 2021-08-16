using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.Administration
{
    public class RegisterAdministratorViewModel 
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }



        public List<UserClaim> Claims { get; set; }

        //===============================================inner class
        public class UserClaim
        {
            public string ClaimType { get; set; }
            public bool IsSelected { get; set; }
        }
        //=====================================================ctor
        public RegisterAdministratorViewModel()
        {
            //nullreferences tegengaan
            Claims = new List<UserClaim>();
        }
    }
}
