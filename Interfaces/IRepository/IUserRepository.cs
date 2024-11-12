using SberBanOnline.Models;

namespace SberBanOnline.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<User?> UpdateUserAsync(int id, User user);
    }
}
