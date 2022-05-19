using Ebank.AccountContext.Domain.Accounts;
using Ebank.AccountContext.Domain.Accounts.Services;
using Framework.Core.Mapper;
using Framework.Core.Persistence;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebank.AccountContext.Infrastructure.Persistence.Accounts
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public void CreateAccount(Account account)
        {
            var mappedAccount = Mapper.Map<Data.Models.Account, Account>(account);
            DbContext.Set<Data.Models.Account>().Add(mappedAccount);
        }
    }
}
