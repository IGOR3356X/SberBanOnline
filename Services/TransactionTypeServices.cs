using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Models;

namespace SberBanOnline.Services
{
    public class TransactionTypeServices : ITransactionTypeServices
    {
        private readonly ITransactionTypeRepository _transactionTypeRepo;

        public TransactionTypeServices(ITransactionTypeRepository repository)
        {
            _transactionTypeRepo = repository;
        }

        public async Task<TransactionType> CreateTransactionTypeAsync(TransactionType transactionType)
        {
            var createResult = await _transactionTypeRepo.CreateTransactionTypeAsync(transactionType);
            return (createResult);
        }

        public async Task<bool> DeleteTransactionTypeAsync(int id)
        {
            var Answer = await _transactionTypeRepo.DeleteTransactionTypeAsync(id);
            return (Answer);
        }

        public async Task<List<TransactionType>> GetAllAsync()
        {
            var listExchangeRate = await _transactionTypeRepo.GetAllAsync();
            return (listExchangeRate);
        }

        public async Task<TransactionType?> GetByIdAsync(int id)
        {
            var selectedCardType = await _transactionTypeRepo.GetByIdAsync(id);
            return (selectedCardType);
        }

        public async Task<TransactionType?> UpdateTransactionTypeAsync(int id, TransactionType transactionType)
        {
            var Updated = await _transactionTypeRepo.UpdateTransactionTypeAsync(id, transactionType);
            return Updated;
        }
    }
}
