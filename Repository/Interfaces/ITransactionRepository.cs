using Application.DTO;
using Application.Responses;
using Application.Searches;
using Domain;

namespace Repository.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>, ICommand<TransactionSearch, PageResponse<TransactionDTO>>
    {
        void CreateTransaction(int walletId, double amount, string type);
    }
}