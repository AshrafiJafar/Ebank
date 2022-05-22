using Ebank.AccountContext.Domain.Accounts;
using Ebank.AccountContext.Domain.Accounts.Exceptions;
using Ebank.AccountContext.Domain.Accounts.Services;
using Framework.Core.Mapper;
using Framework.Core.Persistence;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;

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
        public Account? GetNullOrAccount(int accountNumber)
        {
            var account = DbContext.Set<Data.Models.Account>().AsNoTracking()
                .Include(x => x.Transactions).SingleOrDefault(x => x.AccountNumber == accountNumber);
            return Mapper.Map<Account, Data.Models.Account>(account);
        }
        public Account GetAccountByAccountNumber(int accountNumber)
        {
            var account = DbContext.Set<Data.Models.Account>().AsNoTracking().Include(x => x.Transactions).SingleOrDefault(x => x.AccountNumber == accountNumber);

            if(account == null)
            {
                throw new AccountNumberNotExistException(accountNumber);
            }
            return Mapper.Map<Account, Data.Models.Account>(account);

        }

        public void UpdateAccount(Account account)
        {
            var dbAccount = Mapper.Map<Data.Models.Account, Account>(account);
            DbContext.Update(dbAccount);
        }
    }
}
