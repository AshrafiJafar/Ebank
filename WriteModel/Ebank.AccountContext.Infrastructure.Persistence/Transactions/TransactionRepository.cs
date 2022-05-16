using Ebank.AccountContext.Domain.Transactions;
using Ebank.AccountContext.Domain.Transactions.Services;
using Framework.Core.Persistence;
using Framework.Persistence;

namespace Ebank.AccountContext.Infrastructure.Persistence.Transactions
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
