using Ebank.Constants;
using System.Collections.Generic;

namespace Ebank.ReadModel.Queries.Contracts.DataContracts
{
    public class AccountDto
    {
        public int AccountNumber { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public string OwnerName { get; set; } = null!;
        public AccountType AccountType { get; set; }
        public ICollection<TransactionDto> Transactions { get; set; }
    }
}
