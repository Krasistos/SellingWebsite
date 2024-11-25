using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SellingWebsite.Infrastructure.Data.SeedDb
{
    public class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            var data = new SeedData();

            builder.HasData(data.GuestUserClaim, data.AdminUserClaim);
        }
    }
}
