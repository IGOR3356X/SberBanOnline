using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Models;

namespace SberBanOnline.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepo;
        public UserServices(IUserRepository repository)
        {
            _userRepo = repository;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            var createResult = await _userRepo.CreateUserAsync(user);
            return (createResult);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var Answer = await _userRepo.DeleteUserAsync(id);
            return (Answer);
        }

        public async Task<List<User>> GetAllAsync()
        {
            var listExchangeRate = await _userRepo.GetAllAsync();
            return (listExchangeRate);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var selectedCardType = await _userRepo.GetByIdAsync(id);
            return (selectedCardType);
        }

        public async Task<User?> UpdateUserAsync(int id, User user)
        {
            var Updated = await _userRepo.UpdateUserAsync(id, user);
            return Updated;
        }
    }
}
