using System;
using System.Linq;
using Application.DTO;
using Application.Services.Interfaces;
using Domain;
using Repository.UnitOfWork;

namespace Application.Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Insert(TransactionDTO entity)
        {
            var transaction = new Transaction()
            {
                Amount = entity.Amount,
                CreatedAt = DateTime.Now,
                Type = entity.Type,
                WalletId = entity.WalletId
            };

            _unitOfWork.Transaction.Add(transaction);
            return transaction.Id;
        }

        public void Update(TransactionDTO entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TransactionDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public TransactionDTO GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TransactionDTO> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}