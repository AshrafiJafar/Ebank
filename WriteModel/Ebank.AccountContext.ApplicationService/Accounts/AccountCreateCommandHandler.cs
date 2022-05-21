using Ebank.AccountContext.ApplicationService.Contracts.Accounts;
using Ebank.AccountContext.Domain.Accounts;
using Ebank.AccountContext.Domain.Accounts.Services;
using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ebank.AccountContext.ApplicationService.Accounts
{
    public class AccountCreateCommandHandler : ICommandHandler<AccountCreateCommand>
    {
        private readonly IAccountRepository accountRepository;

        public AccountCreateCommandHandler(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public void Execute(AccountCreateCommand command)
        {
            var account = new Account();
            account.AccountNumber = command.AccountNumber;
            account.OwnerName = command.OwnerName;
            account.CurrencyCode = Constants.CurrencyCode.USD;
            account.AccountType = Constants.AccountType.Individual;
            accountRepository.CreateAccount(account);
        }
    }
}
