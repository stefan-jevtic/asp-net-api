namespace Application.Searches
{
    public class AuthorSearch
    {
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;
    }
}