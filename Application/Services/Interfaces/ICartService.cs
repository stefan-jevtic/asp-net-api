using System.Linq;
using Application.DTO;

namespace Application.Services.Interfaces
{
    public interface ICartService : IService<InsertCartDTO, CartDTO>
    {
        IQueryable<CartDTO> ListCart(int id);
        void Purchase(int id);
        bool CheckItemExist(int userId, int itemId);
        int Insert(InsertCartDTO dto, int userId);
        void Update(UpdateCartDTO entity, int id);
    }
}