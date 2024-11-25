using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SellingWebsite.Infrastructure.Data.Models;
using SellingWebsite.Infrastructure.Data.SeedDb;

namespace SellingWebsite.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserClaimsConfiguration());

            base.OnModelCreating(builder); 
        }

    }
}
