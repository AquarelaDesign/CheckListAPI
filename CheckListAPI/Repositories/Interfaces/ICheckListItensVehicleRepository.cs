using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;

namespace CheckListAPI.Repositories.Interfaces
{
    public interface ICheckListItensVehicleRepository : IBaseRepository
    {
        Task<IEnumerable<CheckListItensVehicleDto>> GetItensVehicleAsync();
        Task<CheckListItensVehicle> GetItensVehicleByIdAsync(int id);
    }
}
