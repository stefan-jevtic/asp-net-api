namespace Domain
{
    public class Cart
    {
        public int Id { get; set; }
        public Dish Dish { get; set; }
        public User User { get; set; }
        public int DishId { get; set; }
        public int UserId { get; set; }
        public uint Quantity { get; set; }
        public double Sum { get; set; }
    }
}