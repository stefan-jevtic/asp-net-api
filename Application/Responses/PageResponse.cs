using System.Collections.Generic;

namespace Application.Responses
{
    public class PageResponse<TEntity>
    {
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<TEntity> Data { get; set; }
    }
}