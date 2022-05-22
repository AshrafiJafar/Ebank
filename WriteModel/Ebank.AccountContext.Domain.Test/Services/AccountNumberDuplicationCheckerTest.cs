using Ebank.AccountContext.Domain.Accounts;
using Ebank.AccountContext.Domain.Accounts.Services;
using Ebank.AccountContext.Domain.Services.Accounts;
using Moq;
using Xunit;

namespace Ebank.AccountContext.Domain.Test.Services
{
    public class AccountNumberDuplicationCheckerTest
    {
        private readonly Mock<IAccountRepository> ExistedAccount = new();
        private readonly Mock<IAccountRepository> NotExistedAccount = new();
        public AccountNumberDuplicationCheckerTest()
        {
            ExistedAccount.Setup(x => x.GetNullOrAccount(1212)).Returns(new Account());
            NotExistedAccount.Setup(x => x.GetNullOrAccount(1213)).Returns((Account?)null);
        }

        [Fact]
        public void ShouldReturnTrueIfAccountExists()
        {
            IAccountNumberDuplicationChecker checker = new AccountNumberDuplicationChecker(ExistedAccount.Object);
            Assert.True(checker.IsDuplicate(1212));
        }
        [Fact]
        public void ShouldReturnTrueIfAccountNotExists()
        {
            IAccountNumberDuplicationChecker checker = new AccountNumberDuplicationChecker(NotExistedAccount.Object);
            Assert.False(checker.IsDuplicate(1212));
        }
    }
}
