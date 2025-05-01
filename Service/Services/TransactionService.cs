using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;
using InventoryTask.Service.Interfaces;

namespace InventoryTask.Service.Services
{
    public class TransactionService(IGenericRepository<Transaction> TransactionRepository) : ITransactionService
    {

        public async Task AddAsync(Transaction Item)
        {
            await TransactionRepository.AddAsync(Item);
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            return await TransactionRepository.DeleteAsync(ID);
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await TransactionRepository.GetAllAsync();
        }

        public async Task<Transaction> GetByIDAsync(int ID)
        {
            return await TransactionRepository.GetByIDAsync(ID);
        }

        public Task SaveAsync()
        {
            return TransactionRepository.SaveAsync();
        }

        public async Task UpdateAsync(Transaction Item)
        {
            await TransactionRepository.SaveAsync();
        }
    }
}
