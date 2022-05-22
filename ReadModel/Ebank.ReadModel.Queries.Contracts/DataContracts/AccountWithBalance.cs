namespace Ebank.ReadModel.Queries.Contracts.DataContracts
{
    public class AccountWithBalanceDto
    {
        public int AccountNumber { get; set; }
        public string CurrencyCode { get; set; }
        public string OwnerName { get; set; } = null!;
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}
