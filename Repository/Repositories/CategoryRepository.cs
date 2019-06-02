using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
            
        }
        
        public LibraryContext LibraryContext
        {
            get { return _context as LibraryContext; }
        }
    }
}