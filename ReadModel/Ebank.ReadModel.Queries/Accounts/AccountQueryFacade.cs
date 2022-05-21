using Ebank.Data.Models;
using Ebank.ReadModel.Context;
using Ebank.ReadModel.Queries.Contracts;
using Ebank.ReadModel.Queries.Contracts.DataContracts;
using Framework.Core.Mapper;
using Framework.Facade;
using Microsoft.AspNetCore.Mvc;

namespace Ebank.ReadModel.Queries.Facade.Accounts
{
    [Route("api/Account/[action]")]
    [ApiController]
    public class AccountQueryFacade : FacadeQueryBase, IAccountsQueryFacade
    {
        private readonly EbankContext db;
        private readonly IMapper mapper;

        public AccountQueryFacade(EbankContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        [HttpGet]
        public IList<AccountDto> GetAllAccounts() {

            return mapper.Map<AccountDto, Account>(db.Accounts.ToList());
        }
    }
}