using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.Controllers
{
    public class ChatController : Controller
    {

        private readonly ILogger<ChatController> _logger;
        private readonly IApplicationRepository _repos;
        private readonly UserManager<ApplicationUser> _userManager;


        public ChatController(ILogger<ChatController> logger, IApplicationRepository appRepos, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _repos = appRepos;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            //var currentUser = await _userManager.GetUserAsync(User);

            //ViewBag.CurrentUsername = currentUser.UserName;

            int i = 5;
            Console.WriteLine(i);


            return View();
        }

        public async Task<IActionResult> Create(ChatMessage aChatMessage)
        {
            if (ModelState.IsValid)
            {
                //14:31
                //aChatMessage.UserNameReceiver = lalaa
                
                return Ok();
            }
            return BadRequest();
        }
    }
}
