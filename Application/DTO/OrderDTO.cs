using System;

namespace Application.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public double Total { get; set; }
        public int UserId { get; set; }
    }
}