using Ebank.AccountContext.Domain.Accounts.Services;

namespace Ebank.AccountContext.Domain.Services.Accounts
{
    public class AccountNumberDuplicationChecker : IAccountNumberDuplicationChecker
    {
        private readonly IAccountRepository accountRepository;

        public AccountNumberDuplicationChecker(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public bool IsDuplicate(int accountNumber)
        {
            return accountRepository.GetNullOrAccount(accountNumber) != null;
        }
    }
}
