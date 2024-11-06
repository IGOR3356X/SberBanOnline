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

        public Task<bool> DeleteCardTypeAsync(int id)
        {
            var Answer = _cardTypeRepo.DeleteCardTypeAsync(id);
            return (Answer);
        }

        public Task<List<CardType>> GetAllAsync()
        {
            var listCardType = _cardTypeRepo.GetAllAsync();
            return (listCardType);
        }

        public Task<CardType?> GetByIdAsync(int id)
        {
            var selectedCardType = _cardTypeRepo.GetByIdAsync(id);
            return (selectedCardType);
        }

        public Task<CardType?> UpdateCardTypeAsync(int id, CardType cardType)
        {
            var Updated = _cardTypeRepo.UpdateCardTypeAsync(id, cardType);
            return (Updated);
        }
    }
}
