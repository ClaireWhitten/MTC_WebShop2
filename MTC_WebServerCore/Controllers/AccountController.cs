using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MTC_WebServerCore.ViewModels.Account;
using MTCmailServer;
using MTCmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTC_WebServerCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;

        //======================================================================================================ctor
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }




        #region ====================================================================================================== Register

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [ValidateAntiForgeryToken] 
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // copier data van model naar IdentityUser
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    //City = model.City,
                    //Zipcode = model.Zipcode
                };


                // sla de user op in de tabel AspNetUsers in de DB
                var result = await _userManager.CreateAsync(user, model.Password);

                // Als de gebruiker succesvol is aangemaakt, 
                // meld je de gebruiker aan met  SignInManager en dan 
                // redirecten naar een actiemethode 
                if (result.Succeeded)
                {
                    //=========================================================================================
                    //een token genereren voor emailbevestiging
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //de url aanmaken
                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        new { userId = user.Id, token = token }, Request.Scheme);


                    //ViewData["Link"] = confirmationLink;
                    ViewData["EmailAdress"] = model.Email;

                    //--------------------------------------------------------------------------email verzenden
                    StringBuilder sbBody = new StringBuilder();

                    sbBody.Append("<hr>");
                    sbBody.Append("<h3>Bedankt voor het vertrouwen in ons product</h3>");
                    sbBody.Append("<p>U bent nog 1 stap verwijderd om je succesvol te registreren, klik op onderstaande link</p>");
                    sbBody.Append($"<a href='{confirmationLink}'><button>Registreer uw email</button></a>");
                    sbBody.Append("<hr>");

                    // nieuwe async versie geschreven, deze ff in commentaar
                    // nieuwe versie controlleerd nog niet op geldig email
                    //-------------------------------------------------------
                   // new MTCmail(
                   //    model.Email,
                   //    "registreer je emailadres",
                   //    sbBody.ToString())
                   //.SendHTML();

                    MTCmail mail = new MTCmail(model.Email, "registreer je emailadres", sbBody.ToString());
                    var emailResult = await mail.SendHtmlAsync();
                    //if (emailResult.Succeeded)
                    //{
                    //}
                    //else
                    //{
                    //}

                    //-----------------------------------------------------------------------------------------

                    return View("SendEmailConfirmationLink");


                    //voorlopig naar de console schrijven, dit moet nog gemaild worden
                    //Console.WriteLine(confirmationLink);
                    //logger.Log(LogLevel.Warning, confirmationLink);
                    //=========================================================================================


                    //Als de gebruiker is aangemeld en de role Admin heeft, is het:
                    //de Admin-gebruiker die een nieuwe gebruiker aan het maken is.
                    //Stuur de  Admin - gebruiker door naar de actie ListUsers
                    if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administration");
                    }

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


            return View(model);
        }

        #endregion




        #region======================================================================================================== Login


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //====================================================================================================
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model, [FromQuery] string returnUrl)
        {
            //=========================================================================
            //deze is niet nodig voor ons omdt we geen external login zoals 
            //google of iets dergelijks gebruiken
            //-----------------------------------------------------------------------------
            //model.ExternalLogins =
            //    (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            //=========================================================================

            if (ModelState.IsValid)
            {

                //============================================================================== bevesting email check
                var user = await _userManager.FindByEmailAsync(model.Email);
                //de gebruiker is gevonden maar het email is nog niet bevestigd
                if (user != null && !user.EmailConfirmed &&
                            (await _userManager.CheckPasswordAsync(user, model.Password)))
                {
                    ModelState.AddModelError(string.Empty, "Dit email is nog niet bevestigd");
                    return View(model);
                }
                //====================================================================================================





                //argumenten van _signInManager.PasswordSignInAsyn
                // 1. username (email in ons geval)
                // 2. paswoord
                // 3. isPersistent (blijvend) cookie
                // 4. locken als het inloggen niet slaagt (nog niet zo duidelijk nu)
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                //als paswoord, gebruikersnaam klopt
                if (result.Succeeded)
                {
                    //deze komt van de inlogpagina
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        //voorkomen dat hackers u willen omleiden naar hun eigen pagina om inloggegevens te krijgen
                        //om bijvoorbeeld naar hun eigen gemaakte inlogpagina te redirecten
                        //daarom hier LocalRedirect() ipv Redirect()
                        //zie hoofdstuk 73
                        return LocalRedirect(returnUrl);
                    }

                    return RedirectToAction("index", "Home");
                }

                //als niet succesvol is ingelogd
                ModelState.AddModelError(string.Empty, "Ongeldige inlog poging");
            }

            return View(model);
        }
        #endregion


        #region===================================================================================================== Logout
        // Gebruik een POST-verzoek om de gebruiker uit te loggen.Het gebruik van een GET-verzoek om de 
        // gebruiker uit te loggen wordt niet aanbevolen omdat de aanpak mogelijk wordt misbruikt.
        // Een kwaadwillende gebruiker kan u misleiden om op een afbeeldingselement te klikken waarbij 
        //  het src-kenmerk is ingesteld op de uitlog-URL van de toepassing. 
        // Hierdoor wordt u onbewust uitgelogd.

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        #endregion

        #region ================================================================================================= IsEmailInUse

        [AcceptVerbs("Get", "Post")] //post niet echt nodig hier denk
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use.");
            }

        }
        #endregion




        #region================================================================================================== AccessDenied
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion




        #region================================================================================================= ConfirmEmail

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("index", "home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
                return View("NotFound");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }


            ViewData["ErrorTitle"] = "Email kan niet bevestigd worden";

            return View("MyError");

        }
        #endregion




        #region================================================================================================ ForgotPassword
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        //-----------------------------------------------------------------------------------------------------------------

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // de user zoeken ahv emailadress
                var user = await _userManager.FindByEmailAsync(model.Email);


                // If the user is found AND Email is confirmed
                // als de gebruiker gevonden is "EN" het email is bevestigd (via mail)
                if (user != null && await _userManager.IsEmailConfirmedAsync(user))
                {
                    // token voor resetpaswoord aanmaken
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    // de link aanmaken om te verzenden
                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                            new { email = model.Email, token = token }, Request.Scheme);

                    // email verzenden
                    //logger.Log(LogLevel.Warning, passwordResetLink);

                    // view ForgotPasswordConfirmation laten zien
                    return View("ForgotPasswordConfirmation");
                }

                //Om accountopsomming en brute force - aanvallen te voorkomen, 
                //moet u de (misschien  met slechtbedoelende) gebruiker
                //niet laten weten dat de gebruiker niet bestaat of het
                //email nog niet bevestigd is 
                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }


        #endregion



        #region ========================================================================================================== TEST

        [HttpGet]
        [Authorize]
        public IActionResult _test_Authorize()
        {
            return View();
        }



        #endregion


    }

}
