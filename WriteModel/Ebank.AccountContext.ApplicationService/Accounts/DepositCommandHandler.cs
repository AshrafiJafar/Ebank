using Ebank.AccountContext.ApplicationService.Contracts.Accounts;
using Ebank.AccountContext.Domain.Accounts.Services;
using Framework.Core.Application;

namespace Ebank.AccountContext.ApplicationService.Accounts
{
    public class DepositCommandHandler : ICommandHandler<DepositCommand>
    {
        private readonly IAccountRepository accountRepository;

        public DepositCommandHandler(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public void Execute(DepositCommand command)
        {
            var account = accountRepository.GetAccountByAccountNumber(command.AccountNumber);
            account.Deposit(command.Amount);
            accountRepository.UpdateAccount(account);

        }
    }
}
