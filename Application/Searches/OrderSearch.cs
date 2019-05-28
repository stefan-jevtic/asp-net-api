namespace Application.Searches
{
    public class OrderSearch
    {
        public double? MaxTotal { get; set; }
        public double? MinTotal { get; set; }
        public int? UserId { get; set; }
        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;
    }
}