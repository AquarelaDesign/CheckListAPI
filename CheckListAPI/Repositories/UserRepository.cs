using CheckListAPI.Data;
using CheckListAPI.Models;
using CheckListAPI.Models.Dtos;
using CheckListAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CheckListAPI.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsersDto>> GetUserAsync()
        {
            return await _context.Users
                .Select(x => new UsersDto { Id = x.Id, Email = x.Email, Password = x.Password, Roles = x.Roles })
                .ToListAsync();
        }

        public async Task<Users> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return user!;
        }

        public async Task<Users> GetByEmailAsync(string email)
        {
            var user = await _context.Users
                .Where(x => x.Email == email).FirstOrDefaultAsync();
            return user!;
        }

    }
}
