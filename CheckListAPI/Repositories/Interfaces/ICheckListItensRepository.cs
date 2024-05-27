using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;

namespace CheckListAPI.Repositories.Interfaces
{
    public interface ICheckListItensRepository : IBaseRepository
    {
        Task<IEnumerable<CheckListItensDto>> GetItensAsync();
        Task<CheckListItens> GetItensByIdAsync(int id);
    }
}
