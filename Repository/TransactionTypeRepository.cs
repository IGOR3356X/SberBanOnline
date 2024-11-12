using SberBanOnline.Data;
using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace SberBanOnline.Repository
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly SberonlineContext _context;
        public TransactionTypeRepository(SberonlineContext context)
        {
            _context = context;
        }
        public async Task<TransactionType> CreateTransactionTypeAsync(TransactionType transactionType)
        {
            await _context.TransactionTypes.AddAsync(transactionType);
            await _context.SaveChangesAsync();
            return transactionType;
        }
        public async Task<bool> DeleteTransactionTypeAsync(int id)
        {
            var deletedEntry = await _context.TransactionTypes.FirstOrDefaultAsync(c =>
           c.Id == id);
            if (deletedEntry == null)
            {
                return false;
            }
            _context.TransactionTypes.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<TransactionType>> GetAllAsync()
        {
            return await _context.TransactionTypes.ToListAsync();
        }
        public async Task<TransactionType?> GetByIdAsync(int id)
        {
            return await _context.TransactionTypes.FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<TransactionType?> UpdateTransactionTypeAsync(int id, TransactionType transactionType)
        {
            var ExitingTransactionType = await _context.TransactionTypes.FirstOrDefaultAsync(c =>
           c.Id == id);
            if (ExitingTransactionType == null)
            {
                return null;
            }
            ExitingTransactionType.Id = id;
            ExitingTransactionType.Name = transactionType.Name;
            await _context.SaveChangesAsync();
            return ExitingTransactionType;
        }
    }
}
