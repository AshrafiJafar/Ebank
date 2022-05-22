using Framework.Core.Persistence;

namespace Ebank.AccountContext.Domain.Accounts.Services
{
    public interface IAccountRepository : IRepository<Account>
    {
        void CreateAccount(Account account);
        Account? GetNullOrAccount(int accountNumber);
        Account GetAccountByAccountNumber(int accountNumber);
        void UpdateAccount(Account account);
    }
}
