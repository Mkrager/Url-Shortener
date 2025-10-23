using Microsoft.AspNetCore.Identity;
using UrlShortener.Application.Constants;

namespace UrlShortener.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Roles.Admin))
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));

            if (!await roleManager.RoleExistsAsync(Roles.Default))
                await roleManager.CreateAsync(new IdentityRole(Roles.Default));
        }
    }
}