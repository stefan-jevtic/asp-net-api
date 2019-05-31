using System.Linq;
using Application.DTO;

namespace Application.Services.Interfaces
{
    public interface ICartService : IService<CartDTO>
    {
        IQueryable<CartDTO> ListCart(int id);
        void Purchase(int id);
    }
}