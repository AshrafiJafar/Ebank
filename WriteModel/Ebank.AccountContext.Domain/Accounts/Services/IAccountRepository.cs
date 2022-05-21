using Framework.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ebank.AccountContext.Domain.Accounts.Services
{
    public interface IAccountRepository : IRepository<Account>
    {
        void CreateAccount(Account account);
    }
}
