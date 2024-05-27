using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;

namespace CheckListAPI.Repositories.Interfaces
{
    public interface ICheckListSupervisorRepository : IBaseRepository
    {
        Task<IEnumerable<CheckListSupervisorDto>> GetSupervisorAsync();
        Task<CheckListSupervisor> GetSupervisorByIdAsync(int id);
    }
}
