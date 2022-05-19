using Ebank.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ebank.ReadModel.Queries.Contracts.DataContracts
{
    public class TransactionDto
    {
        public long Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
        public AccountDto Account { get; set; }
    }
}
