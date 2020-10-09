using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Task4.Data;
using Task4.Models;

namespace Task4.Controllers
{
    [Authorize(Roles = "Unblocked")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, SignInManager<User> signInManager, UserManager<User> userManager, ILogger<HomeController> logger)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }
//        [Route("/")]
        public async Task<IActionResult> Index()
        {
            return View(_userManager.Users.ToList().Where(c => c.Status != null));
        }
        public async Task<IActionResult> Block(string[] selectedIDs)
        {
            foreach (string id in selectedIDs)
            {
                var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
                user.Status = "Blocked";
                await _userManager.AddToRoleAsync(user, "Blocked");
                await _userManager.RemoveFromRoleAsync(user, "Unblocked");
                await _userManager.SetLockoutEnabledAsync(user, true);
                await _context.SaveChangesAsync();    
    //            if (user.LockoutEnabled) await _signInManager.SignOutAsync();
            }
            return Json(new { redirectUrl = Url.Action("Index", "Home"), isRedirect = true });
        }
        public async Task<IActionResult> Unblock(string[] selectedIDs)
        {
            foreach (string id in selectedIDs)
            {
                var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
                user.Status = "Unblocked";
                await _userManager.AddToRoleAsync(user, "Unblocked");
                await _userManager.RemoveFromRoleAsync(user, "Blocked");
                await _userManager.SetLockoutEnabledAsync(user, false);
                await _context.SaveChangesAsync();
            }
            return Json(new { redirectUrl = Url.Action("Index", "Home"), isRedirect = true });
        }

        public async Task<IActionResult> Delete(string[] selectedIDs)
        {
            foreach (string id in selectedIDs)
            {
                var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
                _context.Users.Remove(user);
                await _userManager.SetLockoutEnabledAsync(user, true);
                await _context.SaveChangesAsync();
            }
            return Json(new { redirectUrl = Url.Action("Index", "Home"), isRedirect = true });
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

        //      [Route("Blocked")]
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