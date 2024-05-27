using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;

namespace CheckListAPI.Repositories.Interfaces
{
    public interface ICheckListsHeaderRepository : IBaseRepository
    {
        Task<IEnumerable<CheckListHeaderDto>> GetCheckListAsync();
        Task<CheckListHeader> GetCheckListByIdAsync(int id);
    }
}
