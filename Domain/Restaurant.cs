namespace Domain
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
    }
}