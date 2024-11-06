using SberBanOnline.Models;

namespace SberBanOnline.Interfaces.IServices
{
    public interface ICardServices
    {
        Task<List<Card>> GetAllAsync();
        Task<Card?> GetCardByIdAsync(int id);
        Task<Card> CreateCard(Card card);
        Task<Card?> UpdateCard(Card card, int id);
        Task<bool> DeleteCard(int id);
    }
}
