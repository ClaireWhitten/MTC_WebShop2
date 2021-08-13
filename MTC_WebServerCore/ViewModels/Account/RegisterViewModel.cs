using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        //[Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Paswoord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [DataType(DataType.Password)]
        [Display(Name = "Bevestig paswoord")]
        [Compare("Password",
            ErrorMessage = "Paswoord en bevestigd paswoord komen niet overeen")]
        public string ConfirmPassword { get; set; }
    }
}
