using AutoMapper;
using InventoryTask.Dtos.Transaction;
using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;
using InventoryTask.Service.Interfaces;

namespace InventoryTask.Service.Services
{
    public class TransactionService(IGenericRepository<Transaction> TransactionRepository,IMapper mapper) : ITransactionService
    {

        public async Task AddAsync(TransactionRequest Transaction)
        {
            var TransactionToDb=mapper.Map<Transaction>(Transaction);
            await TransactionRepository.AddAsync(TransactionToDb);
            await TransactionRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = await TransactionRepository.DeleteAsync(id);
            if (!deleted)
            {
                throw new Exception($"Transaction with ID {id} not found.");
            }
            await TransactionRepository.SaveAsync();
        }

        public async Task<List<TransactionResponse>> GetAllAsync()
        {
            var TransactionsfromDB = await TransactionRepository.GetAllAsync();

            var Transactions= mapper.Map<List<TransactionResponse>>(TransactionsfromDB);

           
            return Transactions;
        }

        public async Task<TransactionResponse> GetByIdAsync(int id)
        {
            var TransactionfromDB = await TransactionRepository.GetByIDAsync(id);
            if (TransactionfromDB == null) { return null; }

            var Transaction = mapper.Map<TransactionResponse>(TransactionfromDB);

          
            return Transaction;
        }

        public async Task UpdateAsync(TransactionResponse Transaction)
        {

            var TransactionUpdated = mapper.Map<Transaction> (Transaction);


            TransactionRepository.UpdateAsync(TransactionUpdated);
            await TransactionRepository.SaveAsync();
        }
    }
}
