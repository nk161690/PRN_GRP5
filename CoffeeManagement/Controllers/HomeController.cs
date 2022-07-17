using CoffeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CoffeeManagementContext _context;


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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection values)
        {
            string userName, pass, adminUserName, adminPass, staffUserName, staffPass;
            userName = values["UserName"];
            pass = values["Password"];

            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            adminUserName = conf["Admin:UserName"];
            adminPass = conf["Admin:Password"];
            staffUserName = conf["Staff:UserName"];
            staffPass = conf["Staff:Password"];
            if (userName == adminUserName && pass == adminPass || userName == staffUserName && pass == staffPass)
            {
                HttpContext.Session.SetString("UserName", userName);
                return RedirectToAction(nameof(Index));
            }
            else
                return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("UserName", "");
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
