using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.Controllers
{
    public class ProductAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationRepository _repos;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IApplicationRepository appRepos, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _repos = appRepos;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {var vm=_repos.
        }
    }
}
