using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AmarLenden.Model
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string? FullName { get; set; }
    }
}
