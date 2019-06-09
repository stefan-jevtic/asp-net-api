using Application.DTO;
using Application.Responses;
using Application.Searches;

namespace Application.Services.Interfaces
{
    public interface IAuthorService: IService<InsertUpdateAuthorDTO, AuthorDTO>, ICommand<AuthorSearch, PageResponse<AuthorDTO>>
    {
        
    }
}