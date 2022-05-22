using Ebank.AccountContext.ApplicationService.Contracts.Accounts;
using Ebank.AccountContext.Domain.Accounts.Services;
using Framework.Core.Application;

namespace Ebank.AccountContext.ApplicationService.Accounts
{
    public class WithdrowCommandHandler : ICommandHandler<WithdrowCommand>
    {
        private readonly IAccountRepository accountRepository;

        public WithdrowCommandHandler(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public void Execute(WithdrowCommand command)
        {
            var account = accountRepository.GetAccountByAccountNumber(command.AccountNumber);
            account.Withdraw(command.Amount);
            accountRepository.UpdateAccount(account);
        }
    }
}
