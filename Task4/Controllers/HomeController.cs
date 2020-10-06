using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task4.Models;

namespace Task4.Controllers
{
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

               [Route("display")]
 //       [HttpGet("api/[action]")]
        public IActionResult UserList()
        {
            var users = _userManager.Users;

            var result = new
            {
                recordsTotal = users.Count(),
                data = users.Select(u => new {
                    Id = u.Id,
                    email = u.Email,
                    LockedOut = u.LockoutEnd == null ? String.Empty : "Yes",
                    UserName = u.UserName
                }).ToArray()
            };
            return Json(result);
        }
    }
}
