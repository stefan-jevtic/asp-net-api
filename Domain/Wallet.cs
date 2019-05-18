namespace Domain
{
    public class Wallet
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}