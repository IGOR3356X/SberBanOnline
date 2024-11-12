using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Models;

namespace SberBanOnline.Services
{
    public class UserRoleServices : IUserRoleServices
    {
        private readonly IUserRoleRepository _userRoleRepo;
        public UserRoleServices(IUserRoleRepository repository)
        {
            _userRoleRepo = repository;
        }
        public async Task<UserRole> CreateUserRoleAsync(UserRole userRole)
        {
            var createResult = await _userRoleRepo.CreateUserRoleAsync(userRole);
            return (createResult);
        }

        public async Task<bool> DeleteUserRoleAsync(int id)
        {
            var Answer = await _userRoleRepo.DeleteUserRoleAsync(id);
            return (Answer);
        }

        public async Task<List<UserRole>> GetAllAsync()
        {
            var listExchangeRate = await _userRoleRepo.GetAllAsync();
            return (listExchangeRate);
        }

        public async Task<UserRole?> GetByIdAsync(int id)
        {
            var selectedCardType = await _userRoleRepo.GetByIdAsync(id);
            return (selectedCardType);
        }

        public async Task<UserRole?> UpdateUserRoleAsync(int id, UserRole userRole)
        {
            var Updated = await _userRoleRepo.UpdateUserRoleAsync(id, userRole);
            return Updated;
        }
    }
}
