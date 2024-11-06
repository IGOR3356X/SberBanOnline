using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Models;

namespace SberBanOnline.Services
{
    public class CardServices : ICardServices
    {
        private readonly ICardRepository _cardRepo;

        public CardServices(ICardRepository cardRepository)
        {
            _cardRepo = cardRepository;
        }
        public async Task<Card> CreateCard(Card card)
        {
            var createdCard = await _cardRepo.CreateCard(card);

            return createdCard;
        }

        public async Task<bool> DeleteCard(int id)
        {
            var isDeleted = await _cardRepo.DeleteCard(id);

            if(isDeleted == false)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Card>> GetAllAsync()
        {
            return await _cardRepo.GetAllAsync();
        }

        public async Task<Card?> GetCardByIdAsync(int id)
        {
            return await _cardRepo.GetCardByIdAsync(id);
        }

        public Task<Card?> UpdateCard(Card card, int id)
        {
            var updatedCard = _cardRepo.UpdateCard(card, id);

            return updatedCard;
        }
    }
}
