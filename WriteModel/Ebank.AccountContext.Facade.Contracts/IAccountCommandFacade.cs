using Ebank.AccountContext.ApplicationService.Contracts.Accounts;

namespace Ebank.AccountContext.Facade.Contracts
{
    public interface IAccountCommandFacade
    {
        void CreateAccount(AccountCreateCommand command);
    }
}
