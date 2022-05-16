using Ebank.AccountContext.Domain.Accounts;
using Ebank.AccountContext.Domain.Transactions;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ebank.AccountContext.Infrastructure.Persistence.Accounts.Mapping
{
    public class AccountMapping : EntityMappingBase<Account>
    {
        public override void Initiate(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.AccountNumber);
            builder.Property(x => x.AccountNumber).ValueGeneratedNever();

            builder.HasMany<Transaction>()
                .WithOne()
                .HasForeignKey(p => p.AccountNumber);

        }
    }
}
