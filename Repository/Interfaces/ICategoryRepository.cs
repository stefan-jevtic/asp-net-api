using System;
using Application.DTO;
using Domain;

namespace Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void CreateCategory(CategoryDTO dto);
        void UpdateCategory(CategoryDTO dto, int id);
        void RemoveCategory(int id);
    }
}