using SberBanOnline.Dtos.HomeAdress;
using SberBanOnline.Models;

namespace SberBanOnline.Interfaces.IServices
{
    public interface IHomeAdressServices
    {
        Task<List<HomeAdressDto>> GetAllAsync();
        Task<HomeAdressDto?> GetByIdAsync(int id);
        Task<HomeAdressDto> CreateAdressAsync(CreateHomeAdressRequestDto adressDto);
        Task<bool> DeleteAdressAsync(int id);
        Task<HomeAdressDto?> UpdateAdressAsync(int id, UpdateHomeAdressRequestDto adressDto);
    }
}
