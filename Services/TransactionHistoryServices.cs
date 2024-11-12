using SberBanOnline.Data;
using SberBanOnline.Interfaces.IRepository;
using SberBanOnline.Interfaces.IServices;
using SberBanOnline.Models;

namespace SberBanOnline.Services
{
    public class TransactionHistoryServices : ITransactionHistoryServices
    {
        private readonly ITransactionHistoryRepository _transactionHisRepo;

        public TransactionHistoryServices(ITransactionHistoryRepository transactionHisRepository)
        {
            _transactionHisRepo = transactionHisRepository;
        }

        public async Task<TransactionHistory> CreateTransactionHistoryAsync(TransactionHistory transactionHistory)
        {
            var createResult = await _transactionHisRepo.CreateTransactionHistoryAsync(transactionHistory);
            return (createResult);
        }

        public async Task<bool> DeleteTransactionHistoryAsync(int id)
        {
            var Answer = await _transactionHisRepo.DeleteTransactionHistoryAsync(id);
            return (Answer);
        }

        public async Task<List<TransactionHistory>> GetAllAsync()
        {
            var listExchangeRate = await _transactionHisRepo.GetAllAsync();
            return (listExchangeRate);
        }

        public async Task<TransactionHistory?> GetByIdAsync(int id)
        {
            var selectedCardType = await _transactionHisRepo.GetByIdAsync(id);
            return (selectedCardType);
        }

        public async Task<TransactionHistory?> UpdateTransactionHistoryAsync(int id, TransactionHistory transactionHistory)
        {
            var Updated = await _transactionHisRepo.UpdateTransactionHistoryAsync(id, transactionHistory);
            return Updated;
        }
    }
}
