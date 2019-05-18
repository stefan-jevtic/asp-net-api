using DataAccess;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantContext _context;

        public UnitOfWork(RestaurantContext context)
        {
            _context = context;
        }
        
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}