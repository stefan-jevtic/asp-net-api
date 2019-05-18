namespace Domain
{
    public class Order : BaseEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public double Total { get; set; }
    }
}