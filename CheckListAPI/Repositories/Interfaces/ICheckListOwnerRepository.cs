using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;

namespace CheckListAPI.Repositories.Interfaces
{
    public interface ICheckListOwnerRepository : IBaseRepository
    {
        Task<IEnumerable<CheckListOwnerDto>> GetOwnerAsync();
        Task<CheckListOwner> GetOwnerByIdAsync(int id);
    }
}
