namespace AmarLenden.Model
{
    public class VoucherLine
    {
        public int Id { get; set; }
        public int VoucherId { get; set; }
        public string AccountName { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }

}
