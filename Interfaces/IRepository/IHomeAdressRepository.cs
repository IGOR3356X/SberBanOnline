using SberBanOnline.Models;

namespace SberBanOnline.Interfaces.IRepository
{
    public interface IHomeAdressRepository
    {
        Task<List<HomeAdress>> GetAllAsync();
        Task<HomeAdress?> GetByIdAsync(int id);
        Task<HomeAdress> CreateAdressAsync(HomeAdress homeAdress);
        Task<bool> DeleteAdressAsync(int id);
        Task<HomeAdress?> UpdateAdressAsync(int id, HomeAdress homeAdress);
    }
}
