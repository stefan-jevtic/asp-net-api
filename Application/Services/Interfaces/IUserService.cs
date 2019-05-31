using Application.DTO;
using Application.Responses;
using Application.Searches;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Interfaces
{
    public interface IUserService : IService<AuthDTO>, ICommand<TransactionSearch, PageResponse<TransactionDTO>>
    {
        PageResponse<TransactionDTO> GetTransactions(TransactionSearch search, int userId);
        string Login(AuthDTO dto, IConfiguration config);
    }
}