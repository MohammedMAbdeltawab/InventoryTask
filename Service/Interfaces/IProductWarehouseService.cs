using InventoryTask.Dtos.Product;
using InventoryTask.Dtos.ProductWareHouse;
using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;

namespace InventoryTask.Service.Interfaces
{
    public interface IProductWareHouseService 
    {
        public Task<List<ProductWareHouseDto>> GetAllAsync();
        public Task<ProductWareHouseDto?> GetByIdAsync(int id);
        public Task AddAsync(ProductWareHouseDto product);
        public Task UpdateAsync(ProductWareHouseDto product);
        public Task DeleteAsync(int id);


    }
}

