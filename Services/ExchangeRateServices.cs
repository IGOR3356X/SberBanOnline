using Microsoft.VisualBasic;
using SberBankOnline.Interfaces.Repository;
using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Models;

namespace SberBanOnline.Services
{
    public class ExchangeRateServices : IExchangeRateServices
    {
        private readonly IExchangeRateRepositroy _exchangeRateRepo;
        public ExchangeRateServices(IExchangeRateRepositroy exchangeRateRepo)
        {
            _exchangeRateRepo = exchangeRateRepo;
        }
        public async Task<ExchangeRate> CreateCardTypeAsync(ExchangeRate exchangeRate)
        {
            var createResult = await _exchangeRateRepo.CreateCardTypeAsync(exchangeRate);
            return (createResult);
        }

        public async Task<bool> DeleteCardTypeAsync(int id)
        {
            var Answer = await _exchangeRateRepo.DeleteCardTypeAsync(id);
            return (Answer);
        }

        public async Task<List<ExchangeRate>> GetAllAsync()
        {
            var listExchangeRate = await _exchangeRateRepo.GetAllAsync();
            return (listExchangeRate);
        }

        public async Task<ExchangeRate?> GetByIdAsync(int id)
        {
            var selectedCardType = await _exchangeRateRepo.GetByIdAsync(id);
            return (selectedCardType);
        }

        public async Task<ExchangeRate?> UpdateCardTypeAsync(int id, ExchangeRate exchangeRate)
        {
            var Updated = await _exchangeRateRepo.UpdateCardTypeAsync(id, exchangeRate);
            return Updated;
        }
    }
}
