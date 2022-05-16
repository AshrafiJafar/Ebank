using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ebank.AccountContext.Domain.Accounts
{
    public class Account : IAggregateRoot<Account>, IEntityBase
    {
        public Account() { }
        public int AccountNumber { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public string OwnerName { get; set; } = null!;
        public AccountType AccountType { get; set; }

        public IEnumerable<Expression<Func<Account, object>>> GetAggregateExpressions()
        {
            yield return null;
        }
    }
}
