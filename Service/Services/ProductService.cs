using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;
using InventoryTask.Service.Interfaces;

namespace InventoryTask.Service.Services
{
    public class ProductService(IGenericRepository<Product> ProductRepository) : IProductService
    {



        public async Task AddAsync(Product Item)
        {
            await ProductRepository.AddAsync(Item);
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            return await ProductRepository.DeleteAsync(ID);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await ProductRepository.GetAllAsync();
        }

        public async Task<Product> GetByIDAsync(int ID)
        {
            return await ProductRepository.GetByIDAsync(ID);
        }

        public Task SaveAsync()
        {
            return ProductRepository.SaveAsync();
        }

        public async Task UpdateAsync(Product Item)
        {
            await ProductRepository.SaveAsync();
        }
    }
}
