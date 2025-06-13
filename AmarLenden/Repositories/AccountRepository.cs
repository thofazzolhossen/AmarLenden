using AmarLenden.Interfaces;
using AmarLenden.Model;
using AmarLenden.Repositories;
using AmarLendenAPI.Data;
using AmarLendenAPI.Interfaces;

namespace AmarLendenAPI.Repositories
{
    public class AccountRepository : BasicRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {
        }

    }
}
