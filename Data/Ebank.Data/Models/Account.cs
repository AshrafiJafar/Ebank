namespace Ebank.Data.Models
{
    public class Account
    {
        public Account() { }
        public int AccountNumber { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public string OwnerName { get; set; } = null!;
        public AccountType AccountType { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

    }
}
