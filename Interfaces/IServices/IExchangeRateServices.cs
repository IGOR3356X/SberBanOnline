using SberBanOnline.Models;

namespace SberBanOnline.Interfaces.IServices
{
    public interface IExchangeRateServices
    {
        Task<List<ExchangeRate>> GetAllAsync();
        Task<ExchangeRate?> GetByIdAsync(int id);
        Task<ExchangeRate> CreateCardTypeAsync(ExchangeRate exchangeRate);
        Task<bool> DeleteCardTypeAsync(int id);
        Task<ExchangeRate?> UpdateCardTypeAsync(int id, ExchangeRate exchangeRate);
    }
}
