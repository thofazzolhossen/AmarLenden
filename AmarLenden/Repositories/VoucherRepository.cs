using AmarLenden.Interfaces;
using AmarLenden.Model;
using AmarLendenAPI.Data;
using AmarLendenAPI.Interfaces;

namespace AmarLenden.Repositories
{
    public class VoucherRepository : BasicRepository<Voucher>, IVoucherRepository
    {
        public VoucherRepository(AppDbContext context) : base(context)
        {
        }
    }
}
