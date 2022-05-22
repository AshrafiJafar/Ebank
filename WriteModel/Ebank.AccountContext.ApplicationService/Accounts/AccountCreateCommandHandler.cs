using Ebank.AccountContext.ApplicationService.Contracts.Accounts;
using Ebank.AccountContext.Domain.Accounts;
using Ebank.AccountContext.Domain.Accounts.Services;
using Framework.Core.Application;

namespace Ebank.AccountContext.ApplicationService.Accounts
{
    public class AccountCreateCommandHandler : ICommandHandler<AccountCreateCommand>
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountNumberDuplicationChecker duplicateChecker;

        public AccountCreateCommandHandler(IAccountRepository accountRepository,
            IAccountNumberDuplicationChecker duplicateChecker)
        {
            this.accountRepository = accountRepository;
            this.duplicateChecker = duplicateChecker;
        }
        public void Execute(AccountCreateCommand command)
        {
            var account = new Account(
                duplicateChecker,
                command.AccountNumber,
                command.CurrencyCode,
                command.OwnerName,
                command.AccountType);
            accountRepository.CreateAccount(account);
        }
    }
}
