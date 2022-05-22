using Framework.Core.Application;

namespace Ebank.AccountContext.ApplicationService.Contracts.Accounts
{
    public class DepositCommand : Command
    {
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
