using Application.DTO;
using Domain;

namespace Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        int RegisterUser(AuthDTO dto);
        void UpdateUser(AuthDTO dto, int userId);
        void SoftRemove(int id);
    }
}