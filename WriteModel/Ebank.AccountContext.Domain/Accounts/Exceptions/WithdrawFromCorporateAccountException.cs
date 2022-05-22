using Ebank.AccountContext.Resource;
using Framework.Domain.Exception;

namespace Ebank.AccountContext.Domain.Accounts.Exceptions
{
    public class WithdrawFromCorporateAccountException : DomainException
    {
        override public string Message => ExceptionResource.WithdrawFromCorporateAccount;
    }
}
