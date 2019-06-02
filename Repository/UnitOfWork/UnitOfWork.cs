using DataAccess;
using Domain;
using Repository.Interfaces;
using Repository.Repositories;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;

        public UnitOfWork(LibraryContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            Category = new CategoryRepository(_context);
            Book = new BookRepository(_context);
            Wallet = new WalletRepository(_context);
            Transaction = new TransactionRepository(_context);
            Cart = new CartRepository(_context);
            Order = new OrderRepository(_context);
            Author = new AuthorRepository(_context);
            Role = new RoleRepository(_context);
        }

        public IUserRepository User { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IBookRepository Book { get; private set; }
        public IWalletRepository Wallet { get; }
        public ICartRepository Cart { get; }
        public ITransactionRepository Transaction { get; }
        public IOrderRepository Order { get; }
        public IAuthorRepository Author { get; }
        public IRoleRepository Role { get; }

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