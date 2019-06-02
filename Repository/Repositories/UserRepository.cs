using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
            
        }

        public LibraryContext LibraryContext
        {
            get { return _context as LibraryContext; }
        }
    }
}