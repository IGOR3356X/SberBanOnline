using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Models;

namespace SberBanOnline.Services
{
    public class HomeAdressServices : IHomeAdressServices
    {
        private readonly IHomeAdressRepository _repository;
        public HomeAdressServices(IHomeAdressRepository repository)
        {
            _repository = repository;
        }
        public async Task<HomeAdress> CreateAdressAsync(HomeAdress homeAdress)
        {
            var createResult = await _repository.CreateAdressAsync(homeAdress);
            return (homeAdress);
        }

        public async Task<bool> DeleteAdressAsync(int id)
        {
            var Answer = await _repository.DeleteAdressAsync(id);
            return (Answer);
        }

        public async Task<List<HomeAdress>> GetAllAsync()
        {
            var listExchangeRate = await _repository.GetAllAsync();
            return (listExchangeRate);
        }

        public async Task<HomeAdress?> GetByIdAsync(int id)
        {
            var selectedCardType = await _repository.GetByIdAsync(id);
            return (selectedCardType);
        }

        public async Task<HomeAdress?> UpdateAdressAsync(int id, HomeAdress homeAdress)
        {
            var Updated = await _repository.UpdateAdressAsync(id, homeAdress);
            return Updated;
        }
    }
}
