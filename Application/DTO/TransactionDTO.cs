using System;

namespace Application.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
        public int WalletId { get; set; }
    }
}