namespace Domain
{
    public class Cart
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Sum { get; set; }
    }
}