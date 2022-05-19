using Ebank.Constants;

namespace Ebank.Data.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
        public Account Account { get; set; }

    }
}
