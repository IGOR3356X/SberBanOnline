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

        public Task<bool> DeleteCardTypeAsync(int id)
        {
            var Answer = _exchangeRateRepo.DeleteCardTypeAsync(id);
            return (Answer);
        }

        public Task<List<ExchangeRate>> GetAllAsync()
        {
            var listExchangeRate = _exchangeRateRepo.GetAllAsync();
            return (listExchangeRate);
        }

        public Task<ExchangeRate?> GetByIdAsync(int id)
        {
            var selectedCardType = _exchangeRateRepo.GetByIdAsync(id);
            return (selectedCardType);
        }

        public Task<ExchangeRate?> UpdateCardTypeAsync(int id, ExchangeRate exchangeRate)
        {
            var Updated = _exchangeRateRepo.UpdateCardTypeAsync(id, exchangeRate);
            return (Updated);
        }
    }
}
