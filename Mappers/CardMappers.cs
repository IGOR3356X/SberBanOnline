using SberBanOnline.Dtos.Card;
using SberBanOnline.Dtos.GG;
using SberBanOnline.Models;

namespace SberBanOnline.Mappers
{
    public static class CardMappers
    {
        public static CardDto ToCardDto(this Card cardModel)
        {
            return new CardDto
            {
                Id = cardModel.Id,
                Number = cardModel.Number,
                DateStart = cardModel.DateStart,
                DateEnd = cardModel.DateEnd,
                Cvv = cardModel.Cvv,
                Balance = cardModel.Balance,
                CardTypeId = cardModel.CardTypeId,
                UserId = cardModel.UserId,
            };
        }

        public static Card ToCardFromCreateCardDto(this CreateCardRequestDto cardModel)
        {
            return new Card
            {
                Number = cardModel.Number,
                DateStart = cardModel.DateStart,
                DateEnd = cardModel.DateEnd,
                Cvv = cardModel.Cvv,
                Balance = cardModel.Balance,
                CardTypeId = cardModel.CardTypeId,
                UserId = cardModel.UserId,
            };
        }

        public static Card ToCardFromUpdateCardDto(this UpdateCardRequestDto cardModel)
        {
            return new Card
            {
                Number = cardModel.Number,
                DateStart = cardModel.DateStart,
                DateEnd = cardModel.DateEnd,
                Cvv = cardModel.Cvv,
                Balance = cardModel.Balance,
                CardTypeId = cardModel.CardTypeId,
                UserId = cardModel.UserId,
            };
        }
    }
}
