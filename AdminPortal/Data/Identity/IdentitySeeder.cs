using AdminPortal.Models;
using Microsoft.AspNetCore.Identity;

namespace AdminPortal.Data.Identity;

public static class IdentitySeeder
{
    public static async Task SeedAdminAsync(
        IServiceProvider services,
        IConfiguration configuration)
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        const string adminRole = "Admin";

        var username = configuration["AdminAccount:Username"];
        var password = configuration["AdminAccount:Password"];

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            return;
        }

        if (!await roleManager.RoleExistsAsync(adminRole))
        {
            await roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        var adminUser = await userManager.FindByNameAsync(username);

        if (adminUser is null)
        {
            adminUser = new ApplicationUser
            {
                UserName = username
            };

            var result = await userManager.CreateAsync(adminUser, password);

            if (!result.Succeeded)
            {
                return;
            }
        }

        if (!await userManager.IsInRoleAsync(adminUser, adminRole))
        {
            await userManager.AddToRoleAsync(adminUser, adminRole);
        }
    }
}