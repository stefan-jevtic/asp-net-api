using System.Linq;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(DbContext context) : base(context)
        {
        }
        
        public LibraryContext LibraryContext
        {
            get { return _context as LibraryContext; }
        }
    }
}