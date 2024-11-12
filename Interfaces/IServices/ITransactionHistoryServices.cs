using SberBanOnline.Models;

namespace SberBanOnline.Interfaces.IServices
{
    public interface ITransactionHistoryServices
    {
        Task<List<TransactionHistory>> GetAllAsync();
        Task<TransactionHistory?> GetByIdAsync(int id);
        Task<TransactionHistory> CreateTransactionHistoryAsync(TransactionHistory transactionHistory);
        Task<bool> DeleteTransactionHistoryAsync(int id);
        Task<TransactionHistory?> UpdateTransactionHistoryAsync(int id, TransactionHistory transactionHistory);
    }
}
