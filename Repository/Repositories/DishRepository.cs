using System;
using Application.DTO;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        public DishRepository(DbContext context) : base(context)
        {
        }
        
        public RestaurantContext RestaurantContext
        {
            get { return _context as RestaurantContext; }
        }

        public void InsertDish(DishDTO dto)
        {
            var dish = new Dish()
            {
                Title = dto.Title,
                Ingredients = dto.Ingredients,
                Serving = dto.Serving,
                Price = dto.Price,
                CreatedAt = DateTime.Now,
                CategoryId = dto.CategoryId
            };
            _context.Add(dish);
        }

        public void UpdateDish(DishDTO dto, int id)
        {
            var dish = Get(id);
            dish.Title = dto.Title;
            dish.Ingredients = dto.Ingredients;
            dish.Price = dto.Price;
            dish.Serving = dto.Serving;
            dish.CategoryId = dto.CategoryId;
        }

        public void RemoveDish(int id)
        {
            var dish = Get(id);
            _context.Remove(dish);
        }
    }
}