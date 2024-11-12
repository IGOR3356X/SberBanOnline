using SberBanOnline.Models;

namespace SberBanOnline.Interfaces.IRepository
{
    public interface ITransactionHistoryRepository
    {
        Task<List<TransactionHistory>> GetAllAsync();
        Task<TransactionHistory?> GetByIdAsync(int id);
        Task<TransactionHistory> CreateTransactionHistoryAsync(TransactionHistory transactionHistory);
        Task<bool> DeleteTransactionHistoryAsync(int id);
        Task<TransactionHistory?> UpdateTransactionHistoryAsync(int id, TransactionHistory transactionHistory);
    }
}
