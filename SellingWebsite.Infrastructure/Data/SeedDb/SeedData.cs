using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SellingWebsite.Infrastructure.Data.Models;
using static SellingWebsite.Infrastructure.Constants.CustomClaims;

namespace SellingWebsite.Infrastructure.Data.SeedDb
{
    public class SeedData : ISeedData
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public SeedData(
            IConfiguration _configuration,
            UserManager<ApplicationUser> _userManager,
            RoleManager<IdentityRole> _roleManager)
        {
            configuration = _configuration;
            userManager = _userManager;
            roleManager = _roleManager;
        }

        public async Task SeedAsync()
        {
            await SeedRolesAsync();
            await SeedUsersAsync();
        }

        public async Task SeedRolesAsync()
        {
            var adminRole = "Admin";
            var guestRole = "Guest";

            // Ensure Admin Role
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            // Ensure Guest Role
            if (!await roleManager.RoleExistsAsync(guestRole))
            {
                await roleManager.CreateAsync(new IdentityRole(guestRole));
            }
        }
        public async Task SeedUsersAsync()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            // Seed Guest User
            var guestEmail = configuration["Guest:Email"];
            var guestPassword = configuration["Guest:Password"];
            var guestUser = await userManager.FindByEmailAsync(guestEmail);

            if (guestUser == null)
            {
                var newGuestUser = new ApplicationUser
                {
                    Id = configuration["Guest:Id"],
                    UserName = guestEmail,
                    NormalizedUserName = guestEmail.ToUpper(),
                    Email = guestEmail,
                    NormalizedEmail = guestEmail.ToUpper(),
                    FirstName = "Guest",
                    LastName = "Guestov",
                    EmailConfirmed = true,
                };
                newGuestUser.PasswordHash = hasher.HashPassword(newGuestUser, guestPassword);

                await userManager.CreateAsync(newGuestUser);
                await userManager.AddToRoleAsync(newGuestUser, "Guest");

                // Adding claim
                var guestClaim = new System.Security.Claims.Claim(UserFullNameClaim, "Guest Guestov");
                await userManager.AddClaimAsync(newGuestUser, guestClaim);
            }

            // Seed Admin User
            var adminEmail = configuration["Admin:Email"];
            var adminPassword = configuration["Admin:Password"];
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var newAdminUser = new ApplicationUser
                {
                    Id = configuration["Admin:Id"],
                    UserName = adminEmail,
                    NormalizedUserName = adminEmail.ToUpper(),
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.ToUpper(),
                    FirstName = "Great",
                    LastName = "Admin",
                    EmailConfirmed = true,
                };
                newAdminUser.PasswordHash = hasher.HashPassword(newAdminUser, adminPassword);

                await userManager.CreateAsync(newAdminUser);
                await userManager.AddToRoleAsync(newAdminUser, "Admin");

                // Adding claim
                var adminClaim = new System.Security.Claims.Claim(UserFullNameClaim, "Great Admin");
                await userManager.AddClaimAsync(newAdminUser, adminClaim);
            }
        }

    }
}
