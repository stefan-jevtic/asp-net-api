using DataAccess;
using Domain;
using Repository.Interfaces;
using Repository.Repositories;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantContext _context;

        public UnitOfWork(RestaurantContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            Category = new CategoryRepository(_context);
            Dish = new DishRepository(_context);
            Wallet = new WalletRepository(_context);
            Transaction = new TransactionRepository(_context);
            Cart = new CartRepository(_context);
        }

        public IUserRepository User { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IDishRepository Dish { get; private set; }
        public IWalletRepository Wallet { get; }
        public ICartRepository Cart { get; }
        public ITransactionRepository Transaction { get; }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}