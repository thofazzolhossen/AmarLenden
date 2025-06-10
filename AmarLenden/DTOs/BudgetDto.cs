namespace AmarLenden.DTOs
{
    public class BudgetDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime LastDate { get; set; }
        public double Ammount { get; set; }
    }
}
