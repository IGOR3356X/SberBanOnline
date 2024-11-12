using SberBanOnline.Data;
using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace SberBanOnline.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SberonlineContext _context;
        public UserRepository(SberonlineContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var deletedEntry = await _context.Users.FirstOrDefaultAsync(c =>
           c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }
            _context.Users.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<User?> UpdateUserAsync(int id, User user)
        {
            var ExitingUser = await _context.Users.FirstOrDefaultAsync(c =>
           c.Id == id);
            if (ExitingUser == null)
            {
                return null;
            }
            ExitingUser.Id = id;
            ExitingUser.Name = user.Name;
            ExitingUser.Telephone = user.Telephone;
            ExitingUser.Email = user.Email;
            ExitingUser.Password = user.Password;
            ExitingUser.RoleId = user.RoleId;
            ExitingUser.HomeAdress = user.HomeAdress;
            ExitingUser.Image = user.Image;
            await _context.SaveChangesAsync();
            return ExitingUser;
        }
    }
}
