using System.Collections.Generic;
using Application.DTO;

namespace WebApp.Models
{
    public class UserModel
    {
        public IEnumerable<UserDTO> User { get; set; }
    }
}