using Microsoft.AspNetCore.Identity;
using SellingWebsite.Infrastructure.Data.Models;
using static SellingWebsite.Core.Constants.AdministratorConstants;
namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure admin role exists
            if (!await roleManager.RoleExistsAsync(AdminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(AdminRole));
            }

            // Ensure admin user exists and assign admin role
            var adminUser = await userManager.FindByEmailAsync("admin@mail.com");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser { UserName = AdminUserName, Email = AdminEmail };
                var createResult = await userManager.CreateAsync(adminUser, "admindf1243HH&(@jd3"); // Set admin password

                if (!createResult.Succeeded)
                {
                    Console.WriteLine($"Error creating admin user: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");
                    return;
                }
            }

            if (!await userManager.IsInRoleAsync(adminUser, AdminRole))
            {
                await userManager.AddToRoleAsync(adminUser, AdminRole);
            }

        }
    }
}
