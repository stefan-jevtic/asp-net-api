using System;
using Application.DTO;
using Application.Responses;
using Application.Searches;
using Domain;

namespace Repository.Interfaces
{
    public interface IDishRepository : IRepository<Dish>, ICommand<DishSearch, PageResponse<DishDTO>>
    {
        void InsertDish(DishDTO dto);
        void UpdateDish(DishDTO dto, int id);
        void RemoveDish(int id);
        
    }
}