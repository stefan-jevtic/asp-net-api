using System;

namespace Application.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}