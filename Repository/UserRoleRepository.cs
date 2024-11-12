using SberBanOnline.Data;
using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace SberBanOnline.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly SberonlineContext _context;
        public UserRoleRepository(SberonlineContext context)
        {
            _context = context;
        }
        public async Task<UserRole> CreateUserRoleAsync(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
            return userRole;
        }
        public async Task<bool> DeleteUserRoleAsync(int id)
        {
            var deletedEntry = await _context.UserRoles.FirstOrDefaultAsync(c => c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }
            _context.UserRoles.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<UserRole>> GetAllAsync()
        {
            return await _context.UserRoles.ToListAsync();
        }
        public async Task<UserRole?> GetByIdAsync(int id)
        {
            return await _context.UserRoles.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<UserRole?> UpdateUserRoleAsync(int id, UserRole userRole)
        {
            var ExitingUserRole = await _context.UserRoles.FirstOrDefaultAsync(c =>
           c.Id == id);
            if (ExitingUserRole == null)
            {
                return null;
            }
            ExitingUserRole.Id = id;
            ExitingUserRole.Name = userRole.Name;
            await _context.SaveChangesAsync();
            return ExitingUserRole;
        }
    }
}
