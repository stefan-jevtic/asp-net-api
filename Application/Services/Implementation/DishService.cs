using System;
using System.Linq;
using Application.DTO;
using Application.Responses;
using Application.Searches;
using Application.Services.Interfaces;
using Domain;
using Repository.UnitOfWork;

namespace Application.Services.Implementation
{
    public class DishService : IDishService
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public DishService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        } 

        public int Insert(DishDTO dto)
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
            _unitOfWork.Dish.Add(dish);
            _unitOfWork.Save();
            return dish.Id;
        }

        public void Update(DishDTO dto, int id)
        {
            var dish = _unitOfWork.Dish.Get(id);
            dish.Title = dto.Title;
            dish.Ingredients = dto.Ingredients;
            dish.Price = dto.Price;
            dish.Serving = dto.Serving;
            dish.CategoryId = dto.CategoryId;
            _unitOfWork.Save();
        }

        public void Delete(DishDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            var dish = _unitOfWork.Dish.Get(id);
            _unitOfWork.Dish.Remove(dish);
            _unitOfWork.Save();
        }

        public DishDTO GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<DishDTO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public PageResponse<DishDTO> Execute(DishSearch request)
        {
            var query = _unitOfWork.Dish.GetAll();
            
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