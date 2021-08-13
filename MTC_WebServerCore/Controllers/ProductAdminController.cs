using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.Controllers
{
    public class ProductAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
