using System;
using System.Linq;
using Application.DTO;
using Application.Services.Interfaces;
using Domain;
using Repository.UnitOfWork;

namespace Application.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Insert(CategoryDTO entity)
        {
            var category = new Category()
            {
                Name = entity.Name,
                CreatedAt = DateTime.Now
            };
            _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
            return category.Id;
        }

        public void Update(CategoryDTO entity, int id)
        {
            var category = _unitOfWork.Category.Find(c => c.Id == id).FirstOrDefault();
            category.Name = entity.Name;
            category.ModifiedAt = DateTime.Now;
            _unitOfWork.Save();
        }

        public void Delete(CategoryDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            var category = _unitOfWork.Category.Find(c => c.Id == id).FirstOrDefault();
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
        }

        public CategoryDTO GetById(int id)
        {
            var category = _unitOfWork.Category.Find(c => c.Id == id).Select(c => new CategoryDTO()
            {
                Id = c.Id,
                Name = c.Name,
                CreatedAt = c.CreatedAt
            }).FirstOrDefault();
            return category;
        }

        public IQueryable<CategoryDTO> GetAll()
        {
            var categories = _unitOfWork.Category.GetAll().Select(c => new CategoryDTO()
            {
                Id = c.Id,
                Name = c.Name,
                CreatedAt = c.CreatedAt
            });
            return categories;
        }
    }
}