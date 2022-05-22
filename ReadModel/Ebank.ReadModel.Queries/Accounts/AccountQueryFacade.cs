using Ebank.Data.Models;
using Ebank.ReadModel.Context;
using Ebank.ReadModel.Queries.Contracts;
using Ebank.ReadModel.Queries.Contracts.DataContracts;
using Framework.Core.Mapper;
using Framework.Facade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ebank.ReadModel.Queries.Facade.Accounts
{

    [ApiController]
    public class AccountQueryFacade : FacadeQueryBase, IAccountsQueryFacade
    {
        private readonly EbankContext db;
        private readonly IMapper mapper;

        public AccountQueryFacade(EbankContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("account/{accountNumber}")]
        public AccountWithBalanceDto Get(int accountNumber)
        {

            return db.Accounts.Include(x => x.Transactions).Where(x => x.AccountNumber == accountNumber)
                .Select(x => new AccountWithBalanceDto
                {
                    AccountNumber = x.AccountNumber,
                    AccountType = Enum.GetName(x.AccountType),
                    CurrencyCode = Enum.GetName(x.CurrencyCode),
                    OwnerName = x.OwnerName,
                    Balance = x.Transactions.Sum(x => x.Amount)
                }).SingleOrDefault();
        }

        [HttpGet]
        [Route("accounting/{accountNumber}")]
        public IList<TransactionsDto> GetTransactions(int accountNumber)
        {

            return db.Accounts.Include(x => x.Transactions).SingleOrDefault(x => x.AccountNumber == accountNumber)
                ?.Transactions.Select(x => new TransactionsDto
                {
                    AccountNumber = x.AccountNumber,
                    Amount = x.Amount,
                    TransactionType = Enum.GetName(x.TransactionType),
                    CreatedAt = x.CreatedAt
                }).ToList();

        }
    }
}