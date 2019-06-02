using System;
using Repository.Interfaces;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        ICategoryRepository Category { get; }
        IBookRepository Book { get; }
        IWalletRepository Wallet { get; }
        ICartRepository Cart { get; }
        ITransactionRepository Transaction { get; }
        IOrderRepository Order { get; }
        IAuthorRepository Author { get; }
        IRoleRepository Role { get; }
        void Save();
    }
}