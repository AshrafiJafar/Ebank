using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ebank.AccountContext.Domain.Transactions
{
    public class Transaction : EntityBase<Transaction>, IAggregateRoot<Transaction>
    {
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }

        public IEnumerable<Expression<Func<Transaction, object>>> GetAggregateExpressions()
        {
            yield return null;
        }
    }
}
