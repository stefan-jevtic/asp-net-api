using System;
using Application.DTO;
using Domain;

namespace Repository.Interfaces
{
    public interface IDishRepository : IRepository<Dish>
    {
        void InsertDish(DishDTO dto);
        void UpdateDish(DishDTO dto, int id);
        void RemoveDish(int id);
        
    }
}