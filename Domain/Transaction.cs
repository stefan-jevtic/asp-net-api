using System;

namespace Domain
{
    public class Transaction : BaseEntity
    {
        public double Amount { get; set; }
        public string Type { get; set; }
        public Wallet Wallet { get; set; }
        public int WalletId { get; set; }
    }
}