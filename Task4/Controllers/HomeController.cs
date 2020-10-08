using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task4.Data;
using Task4.Models;

namespace Task4.Controllers
{
    [Authorize(Roles = "admin, guest")]
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(UserManager<User> userManager, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        [HttpPost]
        public IActionResult Delete(string[] selectedIDs)
        {

            // сохранение первичных настроек в файл "StartupSettings.json"
            using (StreamWriter file = System.IO.File.CreateText("666.json"))
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(file, selectedIDs);
            }
            /*

            foreach (var Id in userIDs)
            {
  //              Customer obj = db.Customers.Find(customerID);
  //              db.Customers.Remove(obj);

                User temUser = await _userManager.FindByIdAsync(Id);
                IdentityResult tempMan = await _userManager.UpdateAsync(temUser);
            }
            */

            return Json("All the customers deleted successfully!");
        }


        public IActionResult UsersManage()
        {
            return View();
        }

 //       [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //      [Route("users")]
        //     [Authorize(Roles = "admin")]
        //       [HttpGet("api/[action]")]
        //        <li class="nav-item"><a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="UsersManage">Users Manage</a></li>
        public IActionResult UserList()
        {
            var users = _userManager.Users;

            var result = new
            {
                data = users.Select(u => new {
                    id = u.Id,
                    userName = u.UserName,
                    email = u.Email,
                    regdate = u.RegisterDate.Value.ToString().Remove(u.RegisterDate.Value.ToString().LastIndexOf('.')),
                    lastlogindate = u.LastLoginDate.Value.ToString().Remove(u.LastLoginDate.Value.ToString().LastIndexOf('.')),
                    status = u.Status
                }).ToArray()
            };
            return Json(result);
        }
    }
}