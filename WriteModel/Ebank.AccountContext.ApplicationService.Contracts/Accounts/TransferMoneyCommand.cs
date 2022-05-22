using Framework.Core.Application;

namespace Ebank.AccountContext.ApplicationService.Contracts.Accounts
{
    public class PaymentCommand : Command
    {
        public int SenderAccount { get; set; }
        public int ReceiverAccount { get; set; }
        public int Amount { get; set; }
    }
}
