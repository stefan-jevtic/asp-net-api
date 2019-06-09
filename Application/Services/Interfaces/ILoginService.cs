using Application.DTO;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Interfaces
{
    public interface ILoginService
    {
        string Login(LoginDTO dto, IConfiguration config);
    }
}