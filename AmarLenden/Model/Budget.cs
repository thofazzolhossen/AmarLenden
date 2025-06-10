using System.ComponentModel.DataAnnotations;

namespace AmarLenden.Model
{
    public class Budget
    {
        [Key]
        public int Id { get; set; }
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
