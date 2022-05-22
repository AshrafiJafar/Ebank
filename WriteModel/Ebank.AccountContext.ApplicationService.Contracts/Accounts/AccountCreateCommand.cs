using Ebank.Constants;
using Framework.Core.Application;

namespace Ebank.AccountContext.ApplicationService.Contracts.Accounts
{
    public class AccountCreateCommand : Command
    {
        public int AccountNumber { get; set; }
        public CurrencyCode CurrencyCode { get; set; } 
        public string OwnerName { get; set; } = null!;
        public AccountType AccountType { get; set; } 
    }
}
