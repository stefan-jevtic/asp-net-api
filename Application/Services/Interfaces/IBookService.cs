using Application.DTO;
using Application.Responses;
using Application.Searches;
using Domain;

namespace Application.Services.Interfaces
{
    public interface IBookService : IService<InsertUpdateBookDTO, BookDTO>, ICommand<BookSearch, PageResponse<BookDTO>>
    {
        
    }
}