using System;
using System.Linq;
using Application.DTO;
using Application.Responses;
using Application.Searches;
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

        public PageResponse<DishDTO> Execute(DishSearch request)
        {
            var query = GetAll();
            
            if(request.MinPrice.HasValue)
            {
                query = query.Where(d => d.Price >= request.MinPrice);
            }
            if(request.MaxPrice.HasValue)
            {
                query = query.Where(d => d.Price <= request.MaxPrice);
            }
            if(request.Title != null)
            {
                var keyword = request.Title.ToLower();
                query = query.Where(d => d.Title.ToLower().Contains(keyword));
            }
            if(request.CategoryId != null)
            {
                query = query.Where(d => d.CategoryId == request.CategoryId);
            }
            
            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
            
            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);
            var response = new PageResponse<DishDTO>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PageCount = pagesCount,
                Data = query.Select(d => new DishDTO()
                {
                    Id = d.Id,
                    Title = d.Title,
                    Price = d.Price,
                    Name = d.Category.Name
                })
            };
            return response;
        }
    }
}