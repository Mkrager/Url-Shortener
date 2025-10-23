using Microsoft.AspNetCore.Identity;
using UrlShortener.Application.Constants;

namespace UrlShortener.Identity.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new IdentityUser
            {
                UserName = "defaultUser",
                Email = "defaultUser@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Pa$$word123!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Default);
                }
            }
        }
    }
}