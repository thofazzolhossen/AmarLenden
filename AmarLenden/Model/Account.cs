using System.ComponentModel.DataAnnotations;

namespace AmarLenden.Model
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public int AccountName { get; set; }

    }
}
