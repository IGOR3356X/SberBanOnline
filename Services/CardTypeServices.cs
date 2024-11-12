using SberBankOnline.Interfaces.Repository;
using SberBanOnline.Data;
using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Models;

namespace SberBanOnline.Services
{
    public class CardTypeServices : ICardTypeServices
    {
        private readonly ICardTypeRepository _cardTypeRepo;
        public CardTypeServices(ICardTypeRepository repository)
        {
            _cardTypeRepo = repository;
        }
        public async Task<CardType> CreateCardTypeAsync(CardType cardType)
        {
            var createResult = await _cardTypeRepo.CreateCardTypeAsync(cardType);
            return (createResult);
        }

        public async Task<bool> DeleteCardTypeAsync(int id)
        {
            var Answer = await _cardTypeRepo.DeleteCardTypeAsync(id);
            return (Answer);
        }

        public async Task<List<CardType>> GetAllAsync()
        {
            var listCardType = await _cardTypeRepo.GetAllAsync();
            return (listCardType);
        }

        public async Task<CardType?> GetByIdAsync(int id)
        {
            var selectedCardType = await _cardTypeRepo.GetByIdAsync(id);
            return (selectedCardType);
        }

        public async Task<CardType?> UpdateCardTypeAsync(int id, CardType cardType)
        {
            var Updated = await _cardTypeRepo.UpdateCardTypeAsync(id, cardType);
            return (Updated);
        }
    }
}
