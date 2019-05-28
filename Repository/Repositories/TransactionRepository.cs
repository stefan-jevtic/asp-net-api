using System;
using System.Linq;
using Application.DTO;
using Application.Responses;
using Application.Searches;
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

        public void CreateTransaction(int walletId, double amount, string type)
        {
            var transaction = new Transaction()
            {
                Amount = amount,
                CreatedAt = DateTime.Now,
                Type = type,
                WalletId = walletId
            };

            _context.Add(transaction);
        }
        
        public RestaurantContext RestaurantContext
        {
            get { return _context as RestaurantContext; }
        }

        public PageResponse<TransactionDTO> Execute(TransactionSearch request)
        {
            var query = Find(t => t.WalletId == request.WalletId);
            
            if(request.MinAmount.HasValue)
            {
                query = query.Where(t => t.Amount >= request.MinAmount);
            }
            if(request.MaxAmount.HasValue)
            {
                query = query.Where(t => t.Amount<= request.MaxAmount);
            }
            if(request.Type != null)
            {
                var keyword = request.Type.ToLower();
                query = query.Where(d => d.Type.ToLower().Contains(keyword));
            }
            
            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
            
            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);
            var response = new PageResponse<TransactionDTO>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PageCount = pagesCount,
                Data = query.Select(t => new TransactionDTO()
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    Type = t.Type
                })
            };
            return response;
        }
    }
}