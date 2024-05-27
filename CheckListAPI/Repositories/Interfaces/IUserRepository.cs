using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;

namespace CheckListAPI.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository
    {
        Task<IEnumerable<UsersDto>> GetUserAsync();
        Task<Users> GetUserByIdAsync(int id);
        Task<Users> GetByEmailAsync(string email);
    }
}
