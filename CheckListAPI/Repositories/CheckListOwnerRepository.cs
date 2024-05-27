using CheckListAPI.Data;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CheckListOwnerAPI.Repositories
{
    public class CheckListOwnerRepository : BaseRepository, ICheckListOwnerRepository
    {
        private readonly DataContext _context;

        public CheckListOwnerRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CheckListOwnerDto>> GetOwnerAsync()
        {
            return await _context.CheckListOwner
                .Select(x => new CheckListOwnerDto { Id = x.Id, Name = x.Name, Cpf = x.Cpf, Phone = x.Phone })
                .ToListAsync();
        }

        public async Task<CheckListOwner> GetOwnerByIdAsync(int id)
        {
            var owner = await _context.CheckListOwner
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return owner!;
        }
    }
}
