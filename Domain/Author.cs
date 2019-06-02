using System.Collections.Generic;

namespace Domain
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}