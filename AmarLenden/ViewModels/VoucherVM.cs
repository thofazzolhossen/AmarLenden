using AmarLenden.Model;

namespace AmarLenden.ViewModels
{
    public class VoucherVM
    {
        public string? ReferenceNo { get; set; }
        public DateTime Date { get; set; }
        public string VoucherType { get; set; }

        public List<VoucherLineVM> Lines { get; set; } = new();
    }
}
