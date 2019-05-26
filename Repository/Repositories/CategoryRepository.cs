using System;
using System.Linq;
using Application.DTO;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
            
        }
        
        public RestaurantContext RestaurantContext
        {
            get { return _context as RestaurantContext; }
        }

        public void CreateCategory(CategoryDTO dto)
        {
            var category = new Category()
            {
                Name = dto.Name,
                CreatedAt = DateTime.Now
            };
            _context.Add(category);
        }

        public void UpdateCategory(CategoryDTO dto, int id)
        {
            var category = Find(c => c.Id == id).FirstOrDefault();
            category.Name = dto.Name;
            category.ModifiedAt = DateTime.Now;
        }

        public void RemoveCategory(int id)
        {
            var category = Find(c => c.Id == id).FirstOrDefault();
            _context.Remove(category);
        }
    }
}