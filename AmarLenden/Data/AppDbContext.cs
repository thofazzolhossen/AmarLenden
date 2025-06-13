using AmarLenden.Model;
using Microsoft.EntityFrameworkCore;

namespace AmarLendenAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherLine> VoucherLines { get; set; }


    }
}
