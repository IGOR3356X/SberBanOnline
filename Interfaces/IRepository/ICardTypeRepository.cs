using SberBanOnline.Models;

namespace SberBankOnline.Interfaces.Repository
{
    public interface ICardTypeRepository
    {
        Task<List<CardType>> GetAllAsync();
        Task<CardType?> GetByIdAsync(int id);
        Task<CardType> CreateCardTypeAsync(CardType cardType);
        Task<bool> DeleteCardTypeAsync(int id);
        Task<CardType?> UpdateCardTypeAsync(int id, CardType cardType);
    }
}
