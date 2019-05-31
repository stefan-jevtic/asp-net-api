using Application.DTO;
using Application.Responses;
using Application.Searches;

namespace Application.Services.Interfaces
{
    public interface IDishService : IService<DishDTO>, ICommand<DishSearch, PageResponse<DishDTO>>
    {
        
    }
}