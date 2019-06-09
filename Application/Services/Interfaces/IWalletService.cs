using Application.DTO;

namespace Application.Services.Interfaces
{
    public interface IWalletService : IService<WalletDTO, WalletDTO>
    {
        double InsertMoney(WalletDTO dto, int id);
    }
}