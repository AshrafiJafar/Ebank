using Ebank.AccountContext.ApplicationService.Contracts.Accounts;
using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ebank.AccountContext.ApplicationService.Accounts
{
    public class AccountCreateCommandHandler : ICommandHandler<AccountCreateCommand>
    {
        public void Execute(AccountCreateCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
