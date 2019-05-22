using System;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DbContext context) : base(context)
        {
        }

        public void CreateTransaction(int walletId, double amount)
        {
            var transaction = new Transaction()
            {
                Amount = amount,
                CreatedAt = DateTime.Now,
                Type = "Input",
                WalletId = walletId
            };

            _context.Add(transaction);
        }
        
        public RestaurantContext RestaurantContext
        {
            get { return _context as RestaurantContext; }
        }
    }
}