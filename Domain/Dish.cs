namespace Domain
{
    public class Dish : BaseEntity
    {
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
        public string Serving { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}