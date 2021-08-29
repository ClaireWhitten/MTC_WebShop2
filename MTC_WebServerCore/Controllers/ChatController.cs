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
            var currentUser = await _userManager.GetUserAsync(User);



            if (User.IsInRole("Client"))
            {
                ViewBag.CurrentUsername = currentUser.UserName;
                //var msgsResult = await _repos.ChatMessages.GetAllAsync();
            }


            return View();
        }





        [HttpGet]
        public async Task<ActionResult> GetAllShortClientData(/*[FromBody] string aISBN*/)
        {
            var clientData = await _repos.ChatMessages.GetAllShortClientDataAsync();

            var model = clientData;

            return Ok(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetClientMessagesByClientId([FromQuery]string aClientId)
        {
            var clientData = await _repos.ChatMessages.GetByConditionAsync(cm=>cm.CliendId == aClientId);

            var model = clientData.Data;

            return Ok(model);
        }
    }
}
