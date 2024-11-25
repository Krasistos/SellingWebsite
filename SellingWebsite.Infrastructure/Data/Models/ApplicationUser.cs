using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static SellingWebsite.Infrastructure.Constants.DataConstants.ApplicationUserConstants;

namespace SellingWebsite.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(UserLastNameMaxLength)]
        public string LastName { get; set; }
    }
}
