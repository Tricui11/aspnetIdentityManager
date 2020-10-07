using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task4.Models;

namespace Task4.Controllers
{
    [Authorize(Roles = "admin, guest")]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(UserManager<IdentityUser> userManager, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UsersManage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [Route("users")]
        [Authorize(Roles = "admin")]
        //       [HttpGet("api/[action]")]
        public IActionResult UserList()
        {
            var users = _userManager.Users;

            var result = new
            {
                data = users.Select(u => new {
                    id = u.Id,
                    email = u.Email,
                    lockedOut = u.LockoutEnd == null ? String.Empty : "Yes",
                    userName = u.UserName
                }).ToArray()
            };
            return Json(result);
        }
    }
}