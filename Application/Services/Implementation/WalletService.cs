using System;
using System.Linq;
using Application.DTO;
using Application.Services.Interfaces;
using Domain;
using Repository.UnitOfWork;

namespace Application.Services.Implementation
{
    public class WalletService : IWalletService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionService _service;

        public WalletService(IUnitOfWork unitOfWork, ITransactionService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }
        public int Insert(WalletDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(WalletDTO entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(WalletDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public WalletDTO GetById(int id)
        {
            var wallet = _unitOfWork.Wallet.Find(w => w.UserId == id).FirstOrDefault();
            var dto = new WalletDTO()
            {
                Amount = wallet.Balance
            };
            return dto;
        }

        public IQueryable<WalletDTO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public double InsertMoney(WalletDTO dto, int id)
        {
            if (Double.IsNaN(dto.Amount) || dto.Amount < 1)
            {
                throw new Exception("Please insert positive number greater than 1!");
            }
            var wallet = _unitOfWork.Wallet.Find(w => w.UserId == id).FirstOrDefault();
            wallet.Balance += dto.Amount;
            var transactiondto = new TransactionDTO()
            {
                Amount = dto.Amount,
                Type = "Input",
                WalletId = wallet.Id
            };
            _service.Insert(transactiondto);
            _unitOfWork.Save();
            return wallet.Balance;
        }
    }
}