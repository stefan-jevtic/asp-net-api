using Application.DTO;
using Application.Responses;
using Application.Searches;
using Domain;

namespace Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>, ICommand<OrderSearch, PageResponse<OrderDTO>>
    {
        void InsertOrder(int id, string desc, double total);
    }
}