namespace Application.Searches
{
    public class TransactionSearch
    {
        public double? MaxAmount { get; set; }
        public double? MinAmount { get; set; }
        public string Type { get; set; }
        public int WalletId { get; set; }
        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;
    }
}