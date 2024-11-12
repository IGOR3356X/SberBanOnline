using SberBanOnline.Models;

namespace SberBanOnline.Interfaces.IServices
{
    public interface IUserRoleServices
    {
        Task<List<UserRole>> GetAllAsync();
        Task<UserRole?> GetByIdAsync(int id);
        Task<UserRole> CreateUserRoleAsync(UserRole userRole);
        Task<bool> DeleteUserRoleAsync(int id);
        Task<UserRole?> UpdateUserRoleAsync(int id, UserRole userRole);
    }
}
