using System.ComponentModel.DataAnnotations;

namespace AmarLenden.ViewModels
{
    public class AccountVM
    {
        [Required]
        public string? AccountName { get; set; }
    }
}
