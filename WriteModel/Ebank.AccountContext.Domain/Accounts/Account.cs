using Ebank.AccountContext.Domain.Accounts.Exceptions;
using Ebank.AccountContext.Domain.Accounts.Services;
using Ebank.Constants;
using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ebank.AccountContext.Domain.Accounts
{
    public class Account : IAggregateRoot<Account>, IEntityBase
    {
        public Account() { }
        public Account(IAccountNumberDuplicationChecker duplicateCheker, int accountNumber, CurrencyCode currency, string ownerName, AccountType type)
        {
            SetAccountNumber(accountNumber, duplicateCheker);
            OwnerName= ownerName;
            AccountType = type;
            CurrencyCode= currency;

        }

        public void Deposit(decimal amount)
        {
            if(AccountType != AccountType.Individual)
            {
                throw new DepositToCorporateAccountException();
            }
            Transactions.Add(new Transaction(amount, TransactionType.Deposit));
        }
        public void Withdraw(decimal amount)
        {
            if (AccountType != AccountType.Individual)
            {
                throw new WithdrawFromCorporateAccountException();
            }
            if(Balance < amount)
            {
                throw new NoEnoughBalanceForPaymentException();
            }
            Transactions.Add(new Transaction(-(amount), TransactionType.Withdraw));
        }
        private void SetAccountNumber(int accountNumber, IAccountNumberDuplicationChecker duplicateCheker)
        {
            if(accountNumber <= 0)
            {
                throw new AccountNumberCouldNotBeSmallerThanZeroException();
            }
            if (duplicateCheker.IsDuplicate(accountNumber))
            {
                throw new AccountNumberDuplicationException();
            }
            AccountNumber = accountNumber;
        }

        public void Pay(int amount)
        {
            if(AccountType == AccountType.Corporate)
            {
                throw new PaymentWithCorporateAccountException();
            }
            if(Balance < amount)
            {
                throw new NoEnoughBalanceForPaymentException();
            }
            amount = -(amount);
            Transactions.Add(new Transaction(amount , TransactionType.Payment));
        }
        public void ReceiveByPayment(int amount)
        {
            if (AccountType == AccountType.Individual)
            {
                throw new PaymentToIndividualAccountException();
            }
            Transactions.Add(new Transaction(amount, TransactionType.Payment));
        }
        public int AccountNumber { get; private set; }
        public CurrencyCode CurrencyCode { get; private set; }
        public string OwnerName { get; private set; } = null!;
        public AccountType AccountType { get; private set; }
        public decimal Balance => Transactions.Sum(x => x.Amount);

        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();

        public IEnumerable<Expression<Func<Account, object>>> GetAggregateExpressions()
        {
            yield return x => x.Transactions;
        }

        
    }
}
