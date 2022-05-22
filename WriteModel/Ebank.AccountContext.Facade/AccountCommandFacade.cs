using Ebank.AccountContext.ApplicationService.Contracts.Accounts;
using Ebank.AccountContext.Facade.Contracts;
using Framework.Core.Application;
using Framework.Facade;
using Microsoft.AspNetCore.Mvc;

namespace Ebank.AccountContext.Facade
{
    [ApiController]
    
    public class AccountCommandFacade : FacadeCommandBase, IAccountCommandFacade
    {
        public AccountCommandFacade(ICommandBus commandBus) : base(commandBus)
        {
        }
        [Route("/account")]
        [HttpPost]
        public void CreateAccount(AccountCreateCommand command)
        {
            CommandBus.Dispatch(command);
        }
        [Route("/payment")]
        [HttpPost]
        public void Payment(PaymentCommand command)
        {
            CommandBus.Dispatch(command);
        }
        [Route("/deposit")]
        [HttpPost]
        public void Deposit(DepositCommand command)
        {
            CommandBus.Dispatch(command);
        }
        [Route("/withdraw")]
        [HttpPost]
        public void Withdraw(WithdrowCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
