using Ebank.ReadModel.Queries.Contracts.DataContracts;
using System.Collections.Generic;

namespace Ebank.ReadModel.Queries.Contracts
{
    public interface IAccountsQueryFacade
    {
        AccountWithBalanceDto Get(int accountNumber);
        IList<TransactionsDto> GetTransactions(int accountNumber);
    }
}
