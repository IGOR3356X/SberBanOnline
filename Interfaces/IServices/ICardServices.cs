using SberBanOnline.Dtos.Card;
using SberBanOnline.Dtos.GG;
using SberBanOnline.Models;

namespace SberBanOnline.Interfaces.IServices
{
    public interface ICardServices
    {
        Task<List<CardDto>> GetAllAsync();
        Task<CardDto?> GetCardByIdAsync(int id);
        Task<CardDto> CreateCard(CreateCardRequestDto cardModel);
        Task<CardDto?> UpdateCard(UpdateCardRequestDto cardUpdate, int id);
        Task<bool> DeleteCard(int id);
    }
}
