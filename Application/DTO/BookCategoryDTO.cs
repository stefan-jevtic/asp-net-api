using System.Linq;

namespace Application.DTO
{
    public class BookCategoryDTO
    {
        public BookDTO Book { get; set; }
        public IQueryable<CategoryDTO> Category { get; set; }
        public IQueryable<AuthorDTO> Author { get; set; }
    }
}