namespace SellingWebsite.Infrastructure.Data.SeedDb
{
    public interface ISeedData
    {
        Task SeedAsync();
        Task SeedRolesAsync();
        Task SeedUsersAsync();

    }
}
