using CheckListAPI.Data;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CheckListOwnerAPI.Repositories
{
    public class CheckListItensGroupRepository : BaseRepository, ICheckListItensGroupRepository
    {
        private readonly DataContext _context;

        public CheckListItensGroupRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CheckListItensGroupDto>> GetItensGroupAsync()
        {
            return await _context.CheckListItemGroup
                .Select(x => new CheckListItensGroupDto { Id = x.Id, Name = x.Name })
                .ToListAsync();
        }

        public async Task<CheckListItemGroup> GetItensGroupByIdAsync(int id)
        {
            var itens = await _context.CheckListItemGroup
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return itens!;
        }
    }
}
