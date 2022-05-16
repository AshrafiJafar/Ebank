using Framework.Core.Application;

namespace Ebank.AccountContext.ApplicationService.Contracts.Accounts
{
    public class AccountCreateCommand : Command
    {
        public int AccountNumber { get; set; }
        public string CurrencyCode { get; set; } = null!;
        public string OwnerName { get; set; } = null!;
        public string AccountType { get; set; } = null!;
    }
}
