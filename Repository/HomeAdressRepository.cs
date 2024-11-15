using SberBanOnline.Data;
using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Models;
using Microsoft.EntityFrameworkCore;
using SberBanOnline.Dtos.HomeAdress;

namespace SberBanOnline.Repository
{
    public class HomeAdressRepository : IHomeAdressRepository
    {
        private readonly SberonlineContext _context;
        public HomeAdressRepository(SberonlineContext context)
        {
            _context = context;
        }
        public async Task<HomeAdress> CreateAdressAsync(HomeAdress homeAdress)
        {
            await _context.HomeAdresses.AddAsync(homeAdress);
            await _context.SaveChangesAsync();
            return homeAdress;
        }
        public async Task<bool> DeleteAdressAsync(int id)
        {
            var deletedEntry = await _context.HomeAdresses.FirstOrDefaultAsync(c =>
           c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }
            _context.HomeAdresses.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<HomeAdress>> GetAllAsync()
        {
            return await _context.HomeAdresses.ToListAsync();
        }
        public async Task<HomeAdress?> GetByIdAsync(int id)
        {
            return await _context.HomeAdresses.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<HomeAdress?> UpdateAdressAsync(int id, UpdateHomeAdressRequestDto updateAdress)
        {
            var ExitingHomeAdress = await _context.HomeAdresses.FirstOrDefaultAsync(c =>
           c.Id == id);
            if (ExitingHomeAdress == null)
            {
                return null;
            }
            ExitingHomeAdress.Id = id;
            ExitingHomeAdress.Country = updateAdress.Country;
            ExitingHomeAdress.City = updateAdress.City;
            ExitingHomeAdress.Adress = updateAdress.Adress;
            ExitingHomeAdress.Home = updateAdress.Home;
            ExitingHomeAdress.Apartment = updateAdress.Apartment;
            
            await _context.SaveChangesAsync();

            return ExitingHomeAdress;
        }
    }
}
