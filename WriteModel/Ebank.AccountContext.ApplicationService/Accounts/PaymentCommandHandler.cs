using Ebank.AccountContext.ApplicationService.Contracts.Accounts;
using Ebank.AccountContext.Domain.Accounts;
using Ebank.AccountContext.Domain.Accounts.Services;
using Ebank.Constants;
using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ebank.AccountContext.ApplicationService.Accounts
{
    public class PaymentCommandHandler : ICommandHandler<PaymentCommand>
    {
        private readonly IAccountRepository accountRepository;

        public PaymentCommandHandler(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public void Execute(PaymentCommand command)
        {
            var senderAccount = accountRepository.GetAccountByAccountNumber(command.SenderAccount);
            var receiverAccount = accountRepository.GetAccountByAccountNumber(command.ReceiverAccount);

            senderAccount.Pay(command.Amount);
            receiverAccount.ReceiveByPayment(command.Amount);

            accountRepository.UpdateAccount(senderAccount);
            accountRepository.UpdateAccount(receiverAccount);


        }
    }
}
