using Microsoft.AspNetCore.Identity;

namespace AmarLenden.Model
{
    public class ApplicationUser: IdentityUser
    {
        public string? FullName { get; set; }
    }
}
