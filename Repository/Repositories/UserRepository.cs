using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RestaurantContext context) : base(context)
        {
            
        }

        public RestaurantContext RestaurantContext
        {
            get { return _context as RestaurantContext; }
        }
    }
}