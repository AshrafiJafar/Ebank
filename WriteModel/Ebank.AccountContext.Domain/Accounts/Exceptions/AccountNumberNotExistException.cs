using Ebank.AccountContext.Resource;
using Framework.Domain.Exception;

namespace Ebank.AccountContext.Domain.Accounts.Exceptions
{
    public class AccountNumberNotExistException : DomainException
    {
        private readonly int accountNumber;

        public AccountNumberNotExistException(int accountNumber)
        {
            this.accountNumber = accountNumber;
        }
        override public string Message => string.Format(ExceptionResource.AccountNumberNotExist, accountNumber);
    }

    
}
