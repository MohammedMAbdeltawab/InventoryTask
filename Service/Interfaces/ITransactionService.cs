using InventoryTask.Dtos.Product;
using InventoryTask.Dtos.Transaction;
using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;

namespace InventoryTask.Service.Interfaces
{
    public interface ITransactionService 
    {
        public Task<List<TransactionResponse>> GetAllAsync();
        public Task<TransactionResponse?> GetByIdAsync(int id);
        public Task AddAsync(TransactionRequest transaction);
        public Task UpdateAsync(TransactionResponse transaction);
        public Task DeleteAsync(int id);
    }
}
