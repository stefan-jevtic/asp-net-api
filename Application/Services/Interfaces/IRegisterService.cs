using Application.DTO;

namespace Application.Services.Interfaces
{
    public interface IRegisterService
    {
        int Register(RegisterDTO dto);
    }
}