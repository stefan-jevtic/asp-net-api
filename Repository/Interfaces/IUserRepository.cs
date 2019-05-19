using Application.DTO;
using Domain;

namespace Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        void RegisterUser(AuthDTO dto);
    }
}