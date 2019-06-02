namespace Application.Searches
{
    public class BookSearch
    {
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public int? MinPages { get; set; }
        public int? MaxPages { get; set; }
        public string Title { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;
    }
}