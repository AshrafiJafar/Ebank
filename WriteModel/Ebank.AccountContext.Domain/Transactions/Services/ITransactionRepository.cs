using Framework.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ebank.AccountContext.Domain.Transactions.Services
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
    }
}
