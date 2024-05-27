using CheckListAPI.Data;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CheckListOwnerAPI.Repositories
{
    public class CheckListVehiclesRepository : BaseRepository, ICheckListVehiclesRepository
    {
        private readonly DataContext _context;

        public CheckListVehiclesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CheckListVehicleDto>> GetVehicleAsync()
        {
            return await _context.CheckListVehicles
                .Select(x => new CheckListVehicleDto { Id = x.Id, OwnerId = x.OwnerId, LicensePlate = x.LicensePlate, Year = x.Year, Model = x.Model, Mileage = x.Mileage, Date = x.Date })
                .ToListAsync();
        }

        public async Task<CheckListVehicles> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _context.CheckListVehicles
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return vehicle!;
        }
    }
}
