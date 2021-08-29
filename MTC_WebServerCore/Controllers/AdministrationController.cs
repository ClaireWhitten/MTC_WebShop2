using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MTC_WebServerCore.Models;
using MTC_WebServerCore.ViewModels.Administration;
using MTCmailServer;
using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MTC_WebServerCore.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class AdministrationController : Controller
    {

        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationRepository _repos;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //===================================================================================
        //constructor injectie
        public AdministrationController(RoleManager<ApplicationRole> roleManager,
            IApplicationRepository appRepos,
            SignInManager<ApplicationUser> signInManager,
                                        UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _repos = appRepos;
        }


        public IActionResult Index()
        {
            return View();
        }



        #region ====================================================================================================== Administrator


        [HttpGet]
        public IActionResult RegisterAdministrator()
        {
            //hier hebben we een model nodig om de claims mee te geven
            RegisterAdministratorViewModel model = new RegisterAdministratorViewModel();
           
            // door alle claims loopen welke we hebben aangemaakt in de Claimstore
            foreach (Claim claim in ClaimsStore.AllClaims)
            {
                RegisterAdministratorViewModel.UserClaim userClaim = new RegisterAdministratorViewModel.UserClaim
                {
                    ClaimType = claim.Type
                };
                model.Claims.Add(userClaim);
            }

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> RegisterAdministrator([FromForm] RegisterAdministratorViewModel model)
        {

            if (ModelState.IsValid)
            {
                // copier data van model naar IdentityUser
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };


                //de confiramtion via email is niet nodig omdat deze door een UserAdministrator is toegevoegd
                user.EmailConfirmed = true;

                //een paswoord geven dat toch niet te raden valt
                // sla de user op in de tabel AspNetUsers in de DB
                var result = await _userManager.CreateAsync(user, "jM456__4dlkj4!eé8rxlj_c46F5iiSc456ici5");


                // Als de gebruiker succesvol is aangemaakt, 
                if (result.Succeeded)
                {
                    //======================================================================================== TOEVOEGEN ROLE
                    var resultRoleAdded = await _userManager.AddToRoleAsync(user, "Administrator");


                    //======================================================================================== CLAIMS TOEVOEGEN
                    // Add all the claims that are selected on the UI
                    result = await _userManager.AddClaimsAsync(user,
                        model.Claims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType)));

                    //========================================================================================= EMAIL VERZENDEN
                    // als de gebruiker gevonden is "EN" het email is bevestigd (via mail) dan sturen we een 
                    // email, anders niet en we laten het niet bestaan van het emailadress niet weten aan de gebru!iker 
                    // wegens veiligheidsredenen
                    if (user != null && await _userManager.IsEmailConfirmedAsync(user))
                    {
                        // token voor resetpaswoord aanmaken
                        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                        // de link aanmaken om te verzenden
                        var passwordResetLink = Url.Action("ResetPassword", "Account",
                                new { email = model.Email, token = token }, Request.Scheme);

                        //--------------------------------------------------------------------------email verzenden
                        StringBuilder sbBody = new StringBuilder();

                        sbBody.Append("<hr>");
                        sbBody.Append("<h3>Beste Administrator</h3>");
                        sbBody.Append("<p>Klik op de onderstaande link om jouw passwoord te bevestigen</p>");
                        sbBody.Append($"<a href='{passwordResetLink}'><button>Reset paswoord</button></a>");
                        sbBody.Append("<hr>");

                        List<string> emailAdresses = new List<string>() { "dilentom@gmail.com" };

                        MTCmail mail = new MTCmail(emailAdresses, "Paswoord bevestiging", sbBody.ToString());
                        var emailResult = await mail.SendHtmlAsync();
                        //if (emailResult.Succeeded)
                        //{
                        //}
                        //else
                        //{
                        //}

                    }

                    //-----------------------------------------------------------------------------------------

                    //return View("SendEmailConfirmationLink");

                    //=========================================================================================


                    //Als de gebruiker is aangemeld en de role Admin heeft, is het:
                    //de Admin-gebruiker die een nieuwe gebruiker aan het maken is.
                    //Stuur de  Admin - gebruiker door naar de actie ListUsers
                    //if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    //{
                    //    return RedirectToAction("index", "Home");
                    //}

                    //=============================================================== automatisch inloggen ====

                    //het argument isPersistent wil zeggen als het
                    // false is: dat er een session-cookie wordt weggeschreven
                    // true: dat er een permanent cookie wordt weggeschreven (14dagen)
                    // een sessiecookie verdwijnt wanneer je de browser sluit
                    // een permanent cookie verdwijnd na de expires time (14dagen standaard hier in dit geval)
                    //-------------------------------------------------------------------------
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    //return RedirectToAction("index", "budget");



                    //=========================================================================================
                    return RedirectToAction("OverviewAdministrators", "Administration");
                }

                // ELSE (omdat gereturnd is hierboven)

                // Als er fouten zijn, voeg ze dan toe aan het ModelState-object
                // die worden dan weergegeven door de tag-helper voor het 
                // validatieoverzicht mbv 
                // <div asp-validation-summary="All" class="text-danger"></div>
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            //als geen modelstate niet valid is
            return View(model);
        }

        //=============================================================================================================================================
        [HttpGet]
        public async Task<IActionResult> OverviewAdministratorsAsync()
        {

            var managers = await _userManager.GetUsersInRoleAsync("Administrator");
            return View(managers);
            //return View(new List<ApplicationUser>());
        }

        //=============================================================================================================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAdministrator(string id)
        {
            var user = await _userManager.FindByIdAsync(id);


            if (user == null)
            {
                ViewData["ErrorMessage"] = $"Gebruiker met Id = {id} kan niet gevonden worden";
                return View("NotFound");
            }
            else
            {
                return View("PageInProgress", 
                    new PageInProgressViewModel {
                        Message = "Delete nog niet ondersteund", 
                        ControllerBack = "Administration", 
                        ActionMethodeBack = "OverviewAdministrators" 
                    });
            }
        }

        //==============================================================================================================================================
        [HttpGet] 
        public async Task<IActionResult> EditAdministrator(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewData["ErrorMessage"] = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                // alle claims ophalen van de user
                var existingUserClaims = await _userManager.GetClaimsAsync(user);

                var model = new EditAdministratorViewModel
                {
                    Email = user.Email,
                    Id = user.Id
                };



                // door alle claims loopen welke we hebben aangemaakt in de Claimstore
                foreach (Claim claim in ClaimsStore.AllClaims)
                {
                    EditAdministratorViewModel.UserClaim userClaim = new EditAdministratorViewModel.UserClaim
                    {
                        ClaimType = claim.Type
                    };

                    // als de gebruiker de claim heeft, de property IsSelected of true setten,
                    // dit gebruiken we om de tekstbox aan te vinken
                    if (existingUserClaims.Any(c => c.Type == claim.Type))
                    {
                        userClaim.IsSelected = true;
                    }

                    model.Claims.Add(userClaim);
                }

                return View(model);

            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAdministrator(EditAdministratorViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewData["ErrorMessage"] = $"User with email = {model.Email} cannot be found";
                return View("NotFound");
            }
            else
            {
                // alle claims ophalen van de user
                var existingUserClaims = await _userManager.GetClaimsAsync(user);
                var result = await _userManager.RemoveClaimsAsync(user, existingUserClaims);

                if ( ! result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot remove user existing claims");
                    return View(model);
                }

                //alle geselecteerde claims toevoegen
                result = await _userManager.AddClaimsAsync(user,
                    model.Claims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType)));

                if ( ! result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add selected claims to user");
                    return View(model);
                }

                 return RedirectToAction("OverviewAdministrators");
            }
        }

        //==============================================================================================================================================

        [HttpGet] 
        public async Task<IActionResult> DetailAdministrator(string id)
        {
            return View("PageInProgress",
                new PageInProgressViewModel
                {
                    Message = $"Detail administrator with id: {id}",
                    ControllerBack = "Administration",
                    ActionMethodeBack = "OverviewAdministrators"
                });
        }


        #endregion




        
        #region ====================================================================================================== Supplier

        [HttpGet]
        public IActionResult RegisterSupplier()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> RegisterSupplier([FromForm] RegisterSupplierViewModel model)
        {

            if (ModelState.IsValid)
            {
                // copier data van model naar IdentityUser
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Supplier = model.Supplier
                };
                //user.Addresses = new List<Address>();
                //user.Addresses.Add(model.Address);

                //de confiramtion via email is niet nodig omdat deze door een UserAdministrator is toegevoegd
                user.EmailConfirmed = true;

                //een paswoord geven dat toch niet te raden valt
                // sla de user op in de tabel AspNetUsers in de DB
                var result = await _userManager.CreateAsync(user, "js456__4dlkj4!Neé8rxlj_c465iic4lkj56ici5");


                // Als de gebruiker succesvol is aangemaakt, 
                // meld je de gebruiker aan met  SignInManager en dan 
                // redirecten naar een actiemethode 
                if (result.Succeeded)
                {
                    //======================================================================================== TOEVOEGEN ROLE
                    var resultRoleAdded = await _userManager.AddToRoleAsync(user, "Supplier");

                    ////======================================================================================== TOEVOEGEN SUPPLIER
                    ////eerst id setten van de client
                    //model.Supplier.Id = user.Id;
                    //var resultAddSupplier = await _repos.Suppliers.AddAsync(model.Supplier);




                    //========================================================================================= EMAIL VERZENDEN
                    // als de gebruiker gevonden is "EN" het email is bevestigd (via mail) dan sturen we een 
                    // email, anders niet en we laten het niet bestaan van het emailadress niet weten aan de gebru!iker 
                    // wegens veiligheidsredenen
                    if (user != null && await _userManager.IsEmailConfirmedAsync(user))
                    {
                        // token voor resetpaswoord aanmaken
                        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                        // de link aanmaken om te verzenden
                        var passwordResetLink = Url.Action("ResetPassword", "Account",
                                new { email = model.Email, token = token }, Request.Scheme);

                        //--------------------------------------------------------------------------email verzenden
                        StringBuilder sbBody = new StringBuilder();

                        sbBody.Append("<hr>");
                        sbBody.Append("<h3>Beste supplier</h3>");
                        sbBody.Append("<p>Klik op de onderstaande link om jouw passwoord te bevestigen</p>");
                        sbBody.Append($"<a href='{passwordResetLink}'><button>bevestig paswoord</button></a>");
                        sbBody.Append("<hr>");

                        List<string> emailAdresses = new List<string>() { "dilentom@gmail.com" };

                        MTCmail mail = new MTCmail(emailAdresses, "Paswoord bevestiging", sbBody.ToString());
                        var emailResult = await mail.SendHtmlAsync();
                        //if (emailResult.Succeeded)
                        //{
                        //}
                        //else
                        //{
                        //}

                    }

                    //-----------------------------------------------------------------------------------------

                    //return View("SendEmailConfirmationLink");

                    //=========================================================================================


                    //Als de gebruiker is aangemeld en de role Admin heeft, is het:
                    //de Admin-gebruiker die een nieuwe gebruiker aan het maken is.
                    //Stuur de  Admin - gebruiker door naar de actie ListUsers
                    //if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    //{
                    //    return RedirectToAction("index", "Home");
                    //}

                    //=============================================================== automatisch inloggen ====

                    //het argument isPersistent wil zeggen als het
                    // false is: dat er een session-cookie wordt weggeschreven
                    // true: dat er een permanent cookie wordt weggeschreven (14dagen)
                    // een sessiecookie verdwijnt wanneer je de browser sluit
                    // een permanent cookie verdwijnd na de expires time (14dagen standaard hier in dit geval)
                    //-------------------------------------------------------------------------
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    //return RedirectToAction("index", "budget");



                    //=========================================================================================
                    return RedirectToAction( "OverviewSuppliers", "Administration");

                }

                // ELSE (omdat gereturnd is hierboven)

                // Als er fouten zijn, voeg ze dan toe aan het ModelState-object
                // die worden dan weergegeven door de tag-helper voor het 
                // validatieoverzicht mbv 
                // <div asp-validation-summary="All" class="text-danger"></div>
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            //als geen modelstate niet valid is
            return View(model);
        }
        //=============================================================================================================================================
        [HttpGet]
        public async Task<IActionResult> OverviewSuppliersAsync()
        {

            var managers = await _userManager.GetUsersInRoleAsync("Supplier");
            return View(managers);
            //return View(new List<ApplicationUser>());
        }

        //=============================================================================================================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSupplier(string id)
        {
            var user = await _userManager.FindByIdAsync(id);


            if (user == null)
            {
                ViewData["ErrorMessage"] = $"Gebruiker met Id = {id} kan niet gevonden worden";
                return View("NotFound");
            }
            else
            {
                ////deze delete ook de gegevens uit de bridgetabel AspNetUserRoles
                //var result = await _userManager.DeleteAsync(user);

                //if (result.Succeeded)
                //{
                //   return RedirectToAction("ListUsers",);
                //}


                ////anders als niet succesvol

                //foreach (var error in result.Errors)
                //{
                //    ModelState.AddModelError("", error.Description);
                //}

                //return View("ListUsers");

                //ViewData["ErrorMessage"] = $"Gebruiker met Id = {id} kan niet gevonden worden";
                return View("PageInProgress",
                    new PageInProgressViewModel
                    {
                        Message = "Delete supplier nog niet ondersteund",
                        ControllerBack = "Administration",
                        ActionMethodeBack = "OverviewSuppliers"
                    });
            }
        }

        //==============================================================================================================================================
        [HttpGet]
        public async Task<IActionResult> EditSupplier(string id)
        {
            return View("PageInProgress",
                new PageInProgressViewModel
                {
                    Message = $"edit supplier with id: {id}",
                    ControllerBack = "Administration",
                    ActionMethodeBack = "OverviewSuppliers"
                });
        }
        //==============================================================================================================================================
        [HttpGet]
        public async Task<IActionResult> DetailSupplier(string id)
        {
            return View("PageInProgress",
                new PageInProgressViewModel
                {
                    Message = $"Detail supplier with id: {id}",
                    ControllerBack = "Administration",
                    ActionMethodeBack = "OverviewSuppliers"
                });
        }

        #endregion






        #region ====================================================================================================== Transporter

        [HttpGet]
        public IActionResult RegisterTransporter()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> RegisterTransporter([FromForm] RegisterTransporterViewModel model)
        {

            if (ModelState.IsValid)
            {
                // copier data van model naar IdentityUser
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Transporter = model.Transporter
                };
                //user.Addresses = new List<Address>();
                //user.Addresses.Add(model.Address);

                //de confiramtion via email is niet nodig omdat deze door een UserAdministrator is toegevoegd
                user.EmailConfirmed = true;

                //een paswoord geven dat toch niet te raden valt
                // sla de user op in de tabel AspNetUsers in de DB
                var result = await _userManager.CreateAsync(user, "js456__4dlkj88!!DDrxlj_c465iic4lkj56ici5");


                // Als de gebruiker succesvol is aangemaakt, 
                // meld je de gebruiker aan met  SignInManager en dan 
                // redirecten naar een actiemethode 
                if (result.Succeeded)
                {
                    //======================================================================================== TOEVOEGEN ROLE
                    var resultRoleAdded = await _userManager.AddToRoleAsync(user, "Transporter");




                    //========================================================================================= EMAIL VERZENDEN
                    // als de gebruiker gevonden is "EN" het email is bevestigd (via mail) dan sturen we een 
                    // email, anders niet en we laten het niet bestaan van het emailadress niet weten aan de gebru!iker 
                    // wegens veiligheidsredenen
                    if (user != null && await _userManager.IsEmailConfirmedAsync(user))
                    {
                        // token voor resetpaswoord aanmaken
                        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                        // de link aanmaken om te verzenden
                        var passwordResetLink = Url.Action("ResetPassword", "Account",
                                new { email = model.Email, token = token }, Request.Scheme);

                        //--------------------------------------------------------------------------email verzenden
                        StringBuilder sbBody = new StringBuilder();

                        sbBody.Append("<hr>");
                        sbBody.Append("<h3>Beste Transporter</h3>");
                        sbBody.Append("<p>Klik op de onderstaande link om jouw passwoord te bevestigen</p>");
                        sbBody.Append($"<a href='{passwordResetLink}'><button>bevestig paswoord</button></a>");
                        sbBody.Append("<hr>");

                        List<string> emailAdresses = new List<string>() { "dilentom@gmail.com" };

                        MTCmail mail = new MTCmail(emailAdresses, "Paswoord bevestiging", sbBody.ToString());
                        var emailResult = await mail.SendHtmlAsync();
                        //if (emailResult.Succeeded)
                        //{
                        //}
                        //else
                        //{
                        //}

                    }

                    //-----------------------------------------------------------------------------------------

                    //return View("SendEmailConfirmationLink");

                    //=========================================================================================


                    //Als de gebruiker is aangemeld en de role Admin heeft, is het:
                    //de Admin-gebruiker die een nieuwe gebruiker aan het maken is.
                    //Stuur de  Admin - gebruiker door naar de actie ListUsers
                    //if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    //{
                    //    return RedirectToAction("index", "Home");
                    //}

                    //=============================================================== automatisch inloggen ====

                    //het argument isPersistent wil zeggen als het
                    // false is: dat er een session-cookie wordt weggeschreven
                    // true: dat er een permanent cookie wordt weggeschreven (14dagen)
                    // een sessiecookie verdwijnt wanneer je de browser sluit
                    // een permanent cookie verdwijnd na de expires time (14dagen standaard hier in dit geval)
                    //-------------------------------------------------------------------------
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    //return RedirectToAction("index", "budget");



                    //=========================================================================================
                    return RedirectToAction("OverviewTransporters", "Administration");

                }

                // ELSE (omdat gereturnd is hierboven)

                // Als er fouten zijn, voeg ze dan toe aan het ModelState-object
                // die worden dan weergegeven door de tag-helper voor het 
                // validatieoverzicht mbv 
                // <div asp-validation-summary="All" class="text-danger"></div>
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            //als geen modelstate niet valid is
            return View(model);
        }
        //=============================================================================================================================================
        [HttpGet]
        public async Task<IActionResult> OverviewTransportersAsync()
        {

            var transporters = await _userManager.GetUsersInRoleAsync("Transporter");
            return View(transporters);
            //return View(new List<ApplicationUser>());
        }

        //=============================================================================================================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTransporter(string id)
        {
            var user = await _userManager.FindByIdAsync(id);


            if (user == null)
            {
                ViewData["ErrorMessage"] = $"Gebruiker met Id = {id} kan niet gevonden worden";
                return View("NotFound");
            }
            else
            {
                ////deze delete ook de gegevens uit de bridgetabel AspNetUserRoles
                //var result = await _userManager.DeleteAsync(user);

                //if (result.Succeeded)
                //{
                //   return RedirectToAction("ListUsers",);
                //}


                ////anders als niet succesvol

                //foreach (var error in result.Errors)
                //{
                //    ModelState.AddModelError("", error.Description);
                //}

                //return View("ListUsers");

                //ViewData["ErrorMessage"] = $"Gebruiker met Id = {id} kan niet gevonden worden";
                return View("PageInProgress",
                    new PageInProgressViewModel
                    {
                        Message = "Delete Transporter nog niet ondersteund",
                        ControllerBack = "Administration",
                        ActionMethodeBack = "OverviewTransporters"
                    });
            }
        }

        //==============================================================================================================================================
        [HttpGet]
        public async Task<IActionResult> EditTransporter(string id)
        {
            return View("PageInProgress",
                new PageInProgressViewModel
                {
                    Message = $"edit stransporter with id: {id}",
                    ControllerBack = "Administration",
                    ActionMethodeBack = "OverviewTransporters"
                });
        }
        //==============================================================================================================================================
        [HttpGet]
        public async Task<IActionResult> DetailTransporter(string id)
        {
            return View("PageInProgress",
                new PageInProgressViewModel
                {
                    Message = $"Detail Transporter with id: {id}",
                    ControllerBack = "Administration",
                    ActionMethodeBack = "OverviewTransporters"
                });
        }

        #endregion




    }
}
