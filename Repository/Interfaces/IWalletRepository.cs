using Domain;

namespace Repository.Interfaces
{
    public interface IWalletRepository : IRepository<Wallet>
    {
        void CreateWallet(int id);
        double InsertMoney(double amount, int id);
    }
}