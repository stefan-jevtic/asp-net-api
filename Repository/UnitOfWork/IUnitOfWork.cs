using System;
using Repository.Interfaces;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        ICategoryRepository Category { get; }
        IDishRepository Dish { get; }
        IWalletRepository Wallet { get; }
        ITransactionRepository Transaction { get; }
        void Save();
    }
}