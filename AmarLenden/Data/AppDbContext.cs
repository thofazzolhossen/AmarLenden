using AmarLenden.Model;
using Microsoft.EntityFrameworkCore;

namespace AmarLendenAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Budget> Budgets { get; set; }
    }
}
