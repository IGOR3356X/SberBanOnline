using Microsoft.EntityFrameworkCore;
using SberBanOnline.Data;
using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Models;

namespace SberBanOnline.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly SberonlineContext _context;
        public CardRepository(SberonlineContext context)
        {
            _context = context;
        }
        public async Task<Card> CreateCard(Card card)
        {
            await _context.AddAsync(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<bool> DeleteCard(int id)
        {
            var isExist = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);

            if (isExist == null)
            {
                return false;
            }

            _context.Cards.Remove(isExist);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Card>> GetAllAsync()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task<Card?> GetCardByIdAsync(int id)
        {
            return await _context.Cards.FirstOrDefaultAsync(x =>x.Id == id);
        }

        public async Task<Card?> UpdateCard(Card card, int id)
        {
            var CardUpdate = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);

            if(CardUpdate == null)
            {
                return null;
            }

            CardUpdate.Id = id;
            CardUpdate.Number = card.Number;
            CardUpdate.DateStart = card.DateStart;
            CardUpdate.DateEnd = card.DateEnd;
            CardUpdate.Cvv= card.Cvv;
            CardUpdate.Balance = card.Balance;
            CardUpdate.CardTypeId = card.CardTypeId;
            CardUpdate.UserId = card.UserId;

            await _context.SaveChangesAsync();

            return CardUpdate;
        }
    }
}
