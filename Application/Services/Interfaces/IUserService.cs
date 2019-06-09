using System.Linq;
using Application.DTO;
using Application.Responses;
using Application.Searches;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Interfaces
{
    public interface IUserService : IService<UpdateUserDTO, UserDTO>, ILoginService, IRegisterService, ICommand<TransactionSearch, PageResponse<TransactionDTO>>
    {
        PageResponse<TransactionDTO> GetTransactions(TransactionSearch search, int userId);
        
        void SendMail(MailDTO dto, int id);
    }
}