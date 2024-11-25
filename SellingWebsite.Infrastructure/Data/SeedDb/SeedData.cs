using Microsoft.AspNetCore.Identity;
using SellingWebsite.Infrastructure.Data.Models;
using static SellingWebsite.Infrastructure.Constants.CustomClaims;

namespace SellingWebsite.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public IdentityUserClaim<string> GuestUserClaim { get; set; }
        public IdentityUserClaim<string> AdminUserClaim { get; set; }

        public ApplicationUser GuestUser { get; set; }
        public ApplicationUser AdminUser { get; set; }

        public SeedData()
        {
            SeedUsers();
        }


        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            GuestUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FirstName = "Guest",
                LastName = "Guestov",
            };

            GuestUserClaim = new IdentityUserClaim<string>()
            {
                Id = 2,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Guest Guestov",
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest098@KD(JM+KF*@");
            GuestUser.EmailConfirmed = true;


            AdminUser = new ApplicationUser()
            {
                Id = "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                FirstName = "Great",
                LastName = "Admin",
            };

            AdminUserClaim = new IdentityUserClaim<string>()
            {
                Id = 3,
                ClaimType = UserFullNameClaim,
                UserId = "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                ClaimValue = "Great Admin",
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin:L*(03[vjg");
            AdminUser.EmailConfirmed = true;

        }
    }
}
