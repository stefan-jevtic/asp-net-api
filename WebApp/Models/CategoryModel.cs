using System.Collections.Generic;
using Application.DTO;

namespace WebApp.Models
{
    public class CategoryModel
    {
        public IEnumerable<CategoryDTO> Category { get; set; }
    }
}