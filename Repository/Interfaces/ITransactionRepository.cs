using Domain;

namespace Repository.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        void CreateTransaction(int walletId, double amount, string type);
    }
}