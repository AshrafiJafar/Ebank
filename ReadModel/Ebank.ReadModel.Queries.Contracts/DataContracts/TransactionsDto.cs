using System;

namespace Ebank.ReadModel.Queries.Contracts.DataContracts
{
    public class TransactionsDto
    {
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
