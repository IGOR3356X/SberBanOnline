using SberBanOnline.Dtos.Card;
using SberBanOnline.Dtos.GG;
using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Mappers;
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
        public async Task<CardDto> CreateCard(CreateCardRequestDto cardModel)
        {
            var createdCard = cardModel.ToCardFromCreateCardDto();

            var answer = await _cardRepo.CreateCard(createdCard);

            return answer.ToCardDto();
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

        public async Task<List<CardDto>> GetAllAsync()
        {
            var cardList = await _cardRepo.GetAllAsync();
            return cardList.Select(p => p.ToCardDto()).ToList();
        }

        public async Task<CardDto?> GetCardByIdAsync(int id)
        {
            var promoRow = await _cardRepo.GetCardByIdAsync(id);
            
            if (promoRow != null)
            {
                return promoRow.ToCardDto();
            }
            return null;
        }

        public async Task<CardDto?> UpdateCard(UpdateCardRequestDto updateCard, int id)
        {
            var updatedCard = await _cardRepo.UpdateCard(updateCard.ToCardFromUpdateCardDto(), id);

            if (updatedCard != null)
            {
                return updatedCard.ToCardDto();
            }
            return null;
        }
    }
}
