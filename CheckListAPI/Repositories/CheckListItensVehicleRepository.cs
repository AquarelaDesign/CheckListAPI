using CheckListAPI.Data;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CheckListOwnerAPI.Repositories
{
    public class CheckListItensVehicleRepository : BaseRepository, ICheckListItensVehicleRepository
    {
        private readonly DataContext _context;

        public CheckListItensVehicleRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CheckListItensVehicleDto>> GetItensVehicleAsync()
        {
            return await _context.CheckListItensVehicle
                .Select(x => new CheckListItensVehicleDto { Id = x.Id, VeichleId = x.VeichleId, GroupId = x.GroupId, Description = x.Description, Comments = x.Comments, Status = x.Status })
                .ToListAsync();
        }

        public async Task<CheckListItensVehicle> GetItensVehicleByIdAsync(int id)
        {
            var itens = await _context.CheckListItensVehicle
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return itens!;
        }
    }
}
