using Ebank.AccountContext.Resource;
using Framework.Domain.Exception;

namespace Ebank.AccountContext.Domain.Accounts.Exceptions
{
    public class DepositToCorporateAccountException : DomainException
    {
        override public string Message => ExceptionResource.DepositToCorporateAccount;
    }
}
