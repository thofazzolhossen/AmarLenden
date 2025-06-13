using AmarLenden.Interfaces;
using AmarLenden.Model;
using AmarLendenAPI.Data;
using AmarLendenAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmarLenden.Repositories
{
    public class VoucherRepository : BasicRepository<Voucher>, IVoucherRepository
    {
        private readonly AppDbContext _context;

        public VoucherRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Voucher>> GetAllWithLinesAsync()
        {
            return await _context.Vouchers
                                 .Include(v => v.Lines)
                                 .AsNoTracking()
                                 .ToListAsync();
        }
        public async Task<Voucher?> GetByIdWithLinesAsync(int id)
        {
            return await _context.Vouchers
                                 .Include(v => v.Lines)
                                 .FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
