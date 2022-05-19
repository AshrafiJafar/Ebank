using Ebank.ReadModel.Context;
using Ebank.ReadModel.Queries.Contracts;
using Framework.Core.Mapper;
using Framework.Facade;

namespace Ebank.ReadModel.Queries.Facade.Accounts
{
    public class AccountQueryFacade : FacadeQueryBase, IAccountsQueryFacade
    {
        private readonly EbankContext db;
        private readonly IMapper mapper;

        public AccountQueryFacade(EbankContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        
    }
}