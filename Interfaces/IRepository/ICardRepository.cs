using SberBanOnline.Dtos.Card;
using SberBanOnline.Models;

namespace SberBanOnline.Interfaces.IRepository
{
    public interface ICardRepository
    {
        Task<List<Card>> GetAllAsync();
        Task<Card?> GetCardByIdAsync(int id);
        Task<Card> CreateCard(Card card);
        Task<Card?> UpdateCard(Card updateCard,int id);
        Task<bool> DeleteCard(int id);
    }
}
