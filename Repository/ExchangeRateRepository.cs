using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SberBanOnline.Data;
using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Models;

namespace SberBanOnline.Repository
{
    public class ExchangeRateRepository : IExchangeRateRepositroy
    {
        private readonly SberonlineContext _context;
        public ExchangeRateRepository(SberonlineContext context)
        {
            _context = context;
        }
        public async Task<ExchangeRate> CreateCardTypeAsync(ExchangeRate exchangeRate)
        {
            await _context.ExchangeRates.AddAsync(exchangeRate);
            await _context.SaveChangesAsync();
            return exchangeRate;
        }

        public async Task<bool> DeleteCardTypeAsync(int id)
        {
            var deletedEntry = await _context.ExchangeRates.FirstOrDefaultAsync(c => c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }

            _context.ExchangeRates.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ExchangeRate>> GetAllAsync()
        {
            return await _context.ExchangeRates.ToListAsync();
        }

        public async Task<ExchangeRate?> GetByIdAsync(int id)
        {
            return await _context.ExchangeRates.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<ExchangeRate?> UpdateCardTypeAsync(int id, ExchangeRate exchangeRate)
        {
            var ExitingCardType = await _context.ExchangeRates.FirstOrDefaultAsync(c => c.Id == id);

            if (ExitingCardType == null)
            {
                return null;
            }

            ExitingCardType.Id = id;
            ExitingCardType.Name = exchangeRate.Name;
            ExitingCardType.Price = exchangeRate.Price;

            await _context.SaveChangesAsync();

            return ExitingCardType;
        }
    }
}
