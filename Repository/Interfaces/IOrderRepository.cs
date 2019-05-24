using Domain;

namespace Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        void InsertOrder(int id, string desc, double total);
    }
}