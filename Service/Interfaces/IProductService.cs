using InventoryTask.Dtos.Product;
using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;

namespace InventoryTask.Service.Interfaces
{
    public interface IProductService 
    {
        public Task<List<ProductDto>> GetAllAsync();
        public Task<ProductDto?> GetByIdAsync(int id);
        public Task AddAsync(ProductDto product);
        public Task UpdateAsync(ProductDto product);
        public Task DeleteAsync(int id);
    }
}
