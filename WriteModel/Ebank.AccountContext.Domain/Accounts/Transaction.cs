using Ebank.Constants;
using Framework.Core.Domain;
using Framework.Domain;
using System;

namespace Ebank.AccountContext.Domain.Accounts
{
    public class Transaction : EntityBase<Transaction>, IEntityBase
    {
        public Transaction(decimal amount, TransactionType transactionType)
        {
            TransactionType = transactionType;
            Amount = amount;
            CreatedAt = DateTime.Now;
        }
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
