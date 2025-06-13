using AmarLenden.Model;

namespace AmarLenden.Interfaces
{
    public interface IVoucherRepository : IBasicRepository<Voucher>
    {
        Task<IEnumerable<Voucher>> GetAllWithLinesAsync();
        Task<Voucher?> GetByIdWithLinesAsync(int id);

    }
}
