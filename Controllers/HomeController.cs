using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lee.AADGroupClaims.Models;
using Lee.AADGroupClaims.Authorization;

namespace Lee.AADGroupClaims.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [AuthorizeDevelopers]
        public IActionResult Developers()
        {
            ViewData["Message"] = "Developers group membership.";

            return View();
        }

        public IActionResult IT()
        {
            ViewData["Message"] = "IT Department";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
