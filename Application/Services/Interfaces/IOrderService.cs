using Application.DTO;
using Application.Responses;
using Application.Searches;

namespace Application.Services.Interfaces
{
    public interface IOrderService : IService<OrderDTO>, ICommand<OrderSearch, PageResponse<OrderDTO>>
    {
        
    }
}