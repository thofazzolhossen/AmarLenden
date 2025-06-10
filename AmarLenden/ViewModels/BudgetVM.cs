using System.ComponentModel.DataAnnotations;

namespace AmarLenden.ViewModels
{
    public class BudgetVM
    {
        [Required]
        public string? Description { get; set; }

        [Required]
        public DateTime ApplyDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime LastDate { get; set; }

        [Required]
        public double Ammount { get; set; }
    }
}
