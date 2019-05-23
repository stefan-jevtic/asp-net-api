using Domain;

namespace Repository.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        void InsertInCart(int userId, int dishId, int quantity, double sum);
        int DeleteFromCart(int userId, int id);
    }
}