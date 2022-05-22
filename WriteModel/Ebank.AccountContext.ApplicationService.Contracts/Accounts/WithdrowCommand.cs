using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ebank.AccountContext.ApplicationService.Contracts.Accounts
{
    public class WithdrowCommand : Command
    {
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
