using InternetMessengerApp.Models;
using InternetMessengerApp.Models.Helpers;
using InternetMessengerApp.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InternetMessengerApp.Controllers
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

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = loginModel.User;
            var server = new ServerAPIServices();
            var _token = await server.GetUserJWTToken(user);
            if(_token == "Nieprawidlowe poswiadczenia")
            {
                ViewBag.Failedcount = _token;
                return View(loginModel);
            }
            return RedirectToAction("UserDashboard", new { userId = user.userId, token = _token }) ;

        }
        public async Task<IActionResult> UserDashboard(int userId, string token)
        {
            var userDasboardModel = new UserDashboardModel(userId, token);
            await userDasboardModel.GetAllUserGroups();
            return View(userDasboardModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
