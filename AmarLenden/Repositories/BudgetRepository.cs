using AmarLenden.Model;
using AmarLenden.Repositories;
using AmarLendenAPI.Data;
using AmarLendenAPI.Interfaces;

namespace AmarLendenAPI.Repositories
{
    public class BudgetRepository : BasicRepository<Budget>, IBudgetRepository
    {
        public BudgetRepository(AppDbContext context) : base(context)
        {
        }

    }
}
