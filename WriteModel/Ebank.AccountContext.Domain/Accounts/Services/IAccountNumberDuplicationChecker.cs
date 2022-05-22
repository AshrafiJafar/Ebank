using Framework.Core.Domain;

namespace Ebank.AccountContext.Domain.Accounts.Services
{
    public interface IAccountNumberDuplicationChecker : IDomainService
    {
        bool IsDuplicate(int accountNumber);
    }
}
