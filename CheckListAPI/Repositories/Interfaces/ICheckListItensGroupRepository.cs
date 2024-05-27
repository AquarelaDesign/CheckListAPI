using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;

namespace CheckListAPI.Repositories.Interfaces
{
    public interface ICheckListItensGroupRepository : IBaseRepository
    {
        Task<IEnumerable<CheckListItensGroupDto>> GetItensGroupAsync();
        Task<CheckListItemGroup> GetItensGroupByIdAsync(int id);
    }
}
