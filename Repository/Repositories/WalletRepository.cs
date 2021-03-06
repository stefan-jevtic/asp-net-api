using System.Linq;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class WalletRepository : Repository<Wallet>, IWalletRepository
    {
        public WalletRepository(DbContext context) : base(context)
        {
        }
        
        public LibraryContext LibraryContext
        {
            get { return _context as LibraryContext; }
        }

        public double TakeOfMoney(double amount, int id)
        {
            var wallet = Find(w => w.UserId == id).FirstOrDefault();
            wallet.Balance -= amount;
            return wallet.Balance;
        }
    }
}