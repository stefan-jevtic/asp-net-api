namespace Application.Searches
{
    public class DishSearch
    {
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public string Title { get; set; }
        public int? CategoryId { get; set; }
        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;
    }
}