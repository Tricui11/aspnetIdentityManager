using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Task4.Models;

namespace Task4
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "_Aa123456";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("Unblocked") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Unblocked"));
            }
            if (await roleManager.FindByNameAsync("Blocked") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Blocked"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}