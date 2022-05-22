using Bogus;
using Ebank.AccountContext.Domain.Accounts;
using Ebank.AccountContext.Domain.Accounts.Exceptions;
using Ebank.AccountContext.Domain.Accounts.Services;
using Ebank.Constants;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ebank.AccountContext.Domain.Test
{
    public class AccountTest
    {
        private readonly Mock<IAccountNumberDuplicationChecker> ReturnDuplicateAccount = new();
        private readonly Mock<IAccountNumberDuplicationChecker> ReturnNotDuplicateAccount = new();

        private readonly Account individualAccount = null;
        private readonly Account corporateAccount = null;
        private readonly Account individualAccountWith50Balance = null;
        public AccountTest()
        {
            ReturnDuplicateAccount.Setup(x => x.IsDuplicate(1212)).Returns(true);
            ReturnNotDuplicateAccount.Setup(x => x.IsDuplicate(1212)).Returns(false);

            individualAccount = new Account(ReturnNotDuplicateAccount.Object, 1, CurrencyCode.USD, "Jafar", AccountType.Individual);
            individualAccountWith50Balance = new Account(ReturnNotDuplicateAccount.Object, 3, CurrencyCode.USD, "Jafar", AccountType.Individual);
            individualAccountWith50Balance.Transactions.Add(new Transaction(50, TransactionType.Deposit));

            corporateAccount = new Account(ReturnNotDuplicateAccount.Object, 2, CurrencyCode.USD, "Jafar", AccountType.Corporate);

        }

        public static IEnumerable<Account> GetIncorrectAccountsWitZeroOrMinesAccountNumber()
        {
            Faker<Account> buyerGenerator = new Faker<Account>()
                .RuleFor(buyer => buyer.AccountNumber, b => b.Random.Int(int.MinValue, 0))
                .RuleFor(buyer => buyer.CurrencyCode, b => b.PickRandom<CurrencyCode>())
                .RuleFor(buyer => buyer.OwnerName, b => b.Name.FullName())
                .RuleFor(buyer => buyer.AccountType, b => b.PickRandom<AccountType>());
            return buyerGenerator.Generate(5);
        }
        [Fact]
        public void AccountNumberShouldBeGraterThanZero()
        {
            Assert.Throws<AccountNumberCouldNotBeSmallerThanZeroException>(() =>
                new Account(ReturnDuplicateAccount.Object, 0, CurrencyCode.EUR,"",AccountType.Individual));
            Assert.Throws<AccountNumberCouldNotBeSmallerThanZeroException>(() => 
                new Account(ReturnDuplicateAccount.Object, -1,CurrencyCode.EUR,"",AccountType.Individual));
            Assert.Throws<AccountNumberCouldNotBeSmallerThanZeroException>(() =>
                new Account(ReturnDuplicateAccount.Object, int.MinValue,CurrencyCode.EUR,"",AccountType.Individual));
        }
        [Fact]
        public void AccountNumberCouldNotBeDuplicated()
        {
            Assert.Throws<AccountNumberDuplicationException>(() => 
                new Account(ReturnDuplicateAccount.Object,1212, CurrencyCode.EUR, "", AccountType.Individual));
        }

        [Fact]
        public void PaymentCanNotDoneFromCorporateAccount()
        {
            Assert.Throws<PaymentWithCorporateAccountException>(() => corporateAccount.Pay(10));
        }
        [Fact]
        public void PaymentCanDoneFromIndividualAccount()
        {
            individualAccountWith50Balance.Pay(10);
            Assert.Equal(individualAccountWith50Balance.Transactions.Single(x => x.Amount == -10).Amount, -10);
            Assert.Equal(individualAccountWith50Balance.Transactions.Single(x => x.Amount == -10).TransactionType, TransactionType.Payment);
        }

        [Fact]
        public void PaymentCanDoneToCorporateAccount()
        {
            corporateAccount.ReceiveByPayment(10);
            Assert.Equal(corporateAccount.Transactions.Single(x => x.Amount == 10).Amount, 10);
            Assert.Equal(corporateAccount.Transactions.Single(x => x.Amount == 10).TransactionType, TransactionType.Payment);
        }

        [Fact]
        public void PaymentCanNotDoneToIndividualAccount()
        {
            Assert.Throws<PaymentToIndividualAccountException>(() => individualAccount.ReceiveByPayment(10));
        }

        [Fact]
        public void PaymentCanDoneWithAccountContainsEnoughBalance()
        {
            individualAccountWith50Balance.Pay(10);
            Assert.Equal(individualAccountWith50Balance.Balance, 40);
        }
        [Fact]
        public void PaymentCanNotDoneWithAccountWithoutEnoughBalance()
        {
            Assert.Throws<NoEnoughBalanceForPaymentException>(() => individualAccount.Pay(10));
        }

        [Fact]
        public void OnlyIndividualAccountCanDeposit()
        {
            Assert.Throws<DepositToCorporateAccountException>(() => corporateAccount.Deposit(10));

            individualAccount.Deposit(10);
            Assert.Equal(individualAccount.Transactions.Single(x => x.Amount == 10 && x.TransactionType == TransactionType.Deposit).Amount, 10);
        }

        [Fact]
        public void OnlyIndividualAccountCanWithdraw()
        {
            Assert.Throws<WithdrawFromCorporateAccountException>(() => corporateAccount.Withdraw(10));

            individualAccountWith50Balance.Withdraw(10);
            Assert.Equal(individualAccountWith50Balance.Transactions.Single(x => x.Amount == -10 && x.TransactionType == TransactionType.Withdraw).Amount, -10);
        }
        [Fact]
        public void WithdrawCanNotBeDoneWhileThereIsNotEnoughBalance()
        {
            Assert.Throws<NoEnoughBalanceForPaymentException>(() => individualAccount.Withdraw(10));
        }

        [Fact]
        public void WithdrawCanWhileThereIsEnoughBalance()
        {
            individualAccountWith50Balance.Withdraw(50);
            Assert.Equal(individualAccountWith50Balance.Transactions.Single(x => x.Amount == -50 && x.TransactionType == TransactionType.Withdraw).Amount, -50);
        }
    }
}