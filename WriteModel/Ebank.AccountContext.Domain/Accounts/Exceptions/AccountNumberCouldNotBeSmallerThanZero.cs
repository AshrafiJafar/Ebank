using Ebank.AccountContext.Resource;
using Framework.Domain.Exception;

namespace Ebank.AccountContext.Domain.Accounts.Exceptions
{
    public class AccountNumberCouldNotBeSmallerThanZeroException : DomainException
    {
        override public string Message => ExceptionResource.AccountNumberCouldNotBeSmallerThanZero;
    }
    
}
