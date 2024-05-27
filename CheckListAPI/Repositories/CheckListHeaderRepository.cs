using CheckListAPI.Data;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CheckListAPI.Repositories
{
    public class CheckListHeaderRepository : BaseRepository, ICheckListsHeaderRepository
    {
        private readonly DataContext _context;

        public CheckListHeaderRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CheckListHeaderDto>> GetCheckListAsync()
        {
            return await _context.CheckListHeader
                .Select(x => new CheckListHeaderDto { 
                    Id = x.Id, 
                    Name = x.Name, 
                    Description = x.Description, 
                    VeichleId = x.VeichleId,
                    VeichleItensId = x.VeichleItensId, 
                    OwnerId = x.OwnerId, 
                    SupervisorId = x.SupervisorId, 
                    Comments = x.Comments, 
                    Status = x.Status, 
                    Date = x.Date 
                })
                .ToListAsync();
        }

        public async Task<CheckListHeader> GetCheckListByIdAsync(int id)
        {
            var checklist = await _context.CheckListHeader
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return checklist!;
        }
    }
}
