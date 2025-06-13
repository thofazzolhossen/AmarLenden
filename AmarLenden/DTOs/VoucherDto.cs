namespace AmarLenden.DTOs
{
    public class VoucherDto
    {
        public int Id { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime Date { get; set; }
        public string VoucherType { get; set; }
        public List<VoucherLineDto> Lines { get; set; }
    }
}
