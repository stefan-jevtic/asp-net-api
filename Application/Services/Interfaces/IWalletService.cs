using Application.DTO;

namespace Application.Services.Interfaces
{
    public interface IWalletService : IService<WalletDTO>
    {
        double InsertMoney(WalletDTO dto, int id);
    }
}