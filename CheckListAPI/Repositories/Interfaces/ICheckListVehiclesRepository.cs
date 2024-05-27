using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;

namespace CheckListAPI.Repositories.Interfaces
{
    public interface ICheckListVehiclesRepository : IBaseRepository
    {
        Task<IEnumerable<CheckListVehicleDto>> GetVehicleAsync();
        Task<CheckListVehicles> GetVehicleByIdAsync(int id);
    }
}
