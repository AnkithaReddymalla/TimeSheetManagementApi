using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetManagement.UI.Models;

namespace TimeSheetManagement.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
       
        public IActionResult AdminLogin()
        {
            return View();
        }
        public IActionResult ManagerLogin()
        {
            return View();
        }
        public IActionResult EmployeeLogin()
        {
            return View();
        }
        public IActionResult AdminPostLogin()
        {
            return View();
        }
        public IActionResult ManagerPostLogin()
        {
            return View();
        }
        public IActionResult EmployeePostLogin()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
