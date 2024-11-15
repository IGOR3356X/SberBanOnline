using SberBanOnline.Dtos.HomeAdress;
using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Mappers;
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
        public async Task<HomeAdressDto> CreateAdressAsync(CreateHomeAdressRequestDto adressDto)
        {
            var toModel = adressDto.ToHomeAdressFromDto();
            var createResult = await _repository.CreateAdressAsync(toModel);
            return (createResult.ToHomeAdressDto());
        }

        public async Task<bool> DeleteAdressAsync(int id)
        {
            var Answer = await _repository.DeleteAdressAsync(id);
            return (Answer);
        }

        public async Task<List<HomeAdressDto>> GetAllAsync()
        {
            var listHomeAdress = await _repository.GetAllAsync();
            return listHomeAdress.Select(p => p.ToHomeAdressDto()).ToList();
        }

        public async Task<HomeAdressDto?> GetByIdAsync(int id)
        {
            var addresRow = await _repository.GetByIdAsync(id);

            if (addresRow == null)
            {
                return null;
            }
            return addresRow.ToHomeAdressDto();
        }

        public async Task<HomeAdressDto?> UpdateAdressAsync(int id, UpdateHomeAdressRequestDto updateAdress)
        {
            var updated = await _repository.UpdateAdressAsync(id, updateAdress);

            if (updated != null)
            {
                return updated.ToHomeAdressDto();
            }
            return null;
        }
    }
}
