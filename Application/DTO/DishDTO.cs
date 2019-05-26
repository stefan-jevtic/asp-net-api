using Domain;

namespace Application.DTO
{
    public class DishDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Serving { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}