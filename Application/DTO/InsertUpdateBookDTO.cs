namespace Application.DTO
{
    public class InsertUpdateBookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string ImageUrl { get; set; }
    }
}