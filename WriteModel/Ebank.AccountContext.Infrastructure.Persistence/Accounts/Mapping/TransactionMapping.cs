using Ebank.AccountContext.Domain.Accounts;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ebank.AccountContext.Infrastructure.Persistence.Accounts.Mapping
{
    internal class TransactionMapping : EntityMappingBase<Transaction>
    {
        public override void Initiate(EntityTypeBuilder<Transaction> builder)
        {

        }
    }
}
