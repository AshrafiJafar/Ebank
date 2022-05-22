using Ebank.AccountContext.Resource;
using Framework.Domain.Exception;

namespace Ebank.AccountContext.Domain.Accounts.Exceptions
{
    public class AccountNumberDuplicationException: DomainException
    {
        override public string Message => ExceptionResource.AccountNumberDuplication;
    }
}
