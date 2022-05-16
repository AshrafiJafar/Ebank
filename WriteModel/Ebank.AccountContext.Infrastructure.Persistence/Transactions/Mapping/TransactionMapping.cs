using Ebank.AccountContext.Domain.Transactions;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ebank.AccountContext.Infrastructure.Persistence.Transactions.Mapping
{
    public class TransactionMapping : EntityMappingBase<Transaction>
    {
        public override void Initiate(EntityTypeBuilder<Transaction> builder)
        {

        }
    }
}
