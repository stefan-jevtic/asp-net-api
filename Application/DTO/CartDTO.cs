using Domain;

namespace Application.DTO
{
    public class CartDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public double BookPrice { get; set; }
        public double Sum { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
}