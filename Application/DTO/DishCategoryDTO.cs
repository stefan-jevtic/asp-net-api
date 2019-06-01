using System.Collections;
using System.Linq;
using Domain;

namespace Application.DTO
{
    public class DishCategoryDTO
    {
        public DishDTO Dish { get; set; }
        public IQueryable<CategoryDTO> Category { get; set; }
    }
}