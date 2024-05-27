using CheckListAPI.Data;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CheckListSupervisorAPI.Repositories
{
    public class CheckListSupervisorRepository : BaseRepository, ICheckListSupervisorRepository
    {
        private readonly DataContext _context;

        public CheckListSupervisorRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CheckListSupervisorDto>> GetSupervisorAsync()
        {
            return await _context.CheckListSupervisor
                .Select(x => new CheckListSupervisorDto { Id = x.Id, Name = x.Name })
                .ToListAsync();
        }

        public async Task<CheckListSupervisor> GetSupervisorByIdAsync(int id)
        {
            var supervisor = await _context.CheckListSupervisor
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return supervisor!;
        }
    }
}
