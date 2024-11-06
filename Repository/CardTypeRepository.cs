using Microsoft.EntityFrameworkCore;
using SberBanOnline.Data;
using SberBankOnline.Interfaces.Repository;
using SberBanOnline.Models;

namespace SberBankOnline.Repository
{
    public class CardTypeRepository : ICardTypeRepository
    {
        private readonly SberonlineContext _context;
        public CardTypeRepository(SberonlineContext context)
        {
            _context = context;
        }

        public async Task<CardType> CreateCardTypeAsync(CardType cardType)
        {
            await _context.CardTypes.AddAsync(cardType);
            await _context.SaveChangesAsync();
            return cardType;
        }

        public async Task<bool> DeleteCardTypeAsync(int id)
        {
            var deletedEntry = await _context.CardTypes.FirstOrDefaultAsync(c => c.Id == id);
            if (deletedEntry == null)
            {
               return false;
            }

            _context.CardTypes.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CardType>> GetAllAsync()
        {
            return await _context.CardTypes.ToListAsync();
        }

        public async Task<CardType?> GetByIdAsync(int id)
        {
            return await _context.CardTypes.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<CardType?> UpdateCardTypeAsync(int id, CardType cardType)
        {
            var ExitingCardType = await _context.CardTypes.FirstOrDefaultAsync(c => c.Id == id);

            if (ExitingCardType == null)
            {
                return null;
            }

            ExitingCardType.Id = id;
            ExitingCardType.Name = cardType.Name;
            ExitingCardType.Cards = cardType.Cards;

            await _context.SaveChangesAsync();

            return ExitingCardType;
        }
    }
}
