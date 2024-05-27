using CheckListAPI.Data;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CheckListOwnerAPI.Repositories
{
    public class CheckListItensRepository : BaseRepository, ICheckListItensRepository
    {
        private readonly DataContext _context;

        public CheckListItensRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CheckListItensDto>> GetItensAsync()
        {
            return await _context.CheckListsItens
                .Select(x => new CheckListItensDto { Id = x.Id, GroupId = x.GroupId, Description = x.Description, Comments = x.Comments, Status = x.Status })
                .ToListAsync();
        }

        public async Task<CheckListItens> GetItensByIdAsync(int id)
        {
            var itens = await _context.CheckListsItens
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return itens!;
        }
    }
}
