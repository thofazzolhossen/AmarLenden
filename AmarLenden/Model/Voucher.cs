namespace AmarLenden.Model
{
    public class Voucher
    {
        public int Id { get; set; }
        public string? ReferenceNo { get; set; }
        public DateTime Date { get; set; }
        public string? VoucherType { get; set; }

        public List<VoucherLine> Lines { get; set; } = new();
    }

}
