using SberBanOnline.Models;

namespace SberBanOnline.Interfaces.IServices
{
    public interface ICardTypeServices
    {
        Task<List<CardType>> GetAllAsync();
        Task<CardType?> GetByIdAsync(int id);
        Task<CardType> CreateCardTypeAsync(CardType cardType);
        Task<CardType?> UpdateCardTypeAsync(int id, CardType cardType);
        Task<bool> DeleteCardTypeAsync(int id);
    }
}
