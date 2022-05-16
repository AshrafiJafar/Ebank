using Ebank.AccountContext.ApplicationService.Contracts.Accounts;
using Ebank.AccountContext.Facade.Contracts;
using Framework.Core.Application;
using Framework.Facade;
using Microsoft.AspNetCore.Mvc;

namespace Ebank.AccountContext.Facade
{
    [ApiController]
    [Route("/account")]
    public class AccountCommandFacade : FacadeCommandBase, IAccountCommandFacade
    {
        public AccountCommandFacade(ICommandBus commandBus) : base(commandBus)
        {
        }
        [HttpPost]
        public void CreateAccount(AccountCreateCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
