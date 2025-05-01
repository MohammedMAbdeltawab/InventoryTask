using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;
using InventoryTask.Service.Interfaces;

namespace InventoryTask.Service.Services
{
    public class ProductWarehouseService(IGenericRepository<ProductWarehouse> ProductWarehouseRepository) : IProductWarehouseService
    {

        public async Task AddAsync(ProductWarehouse Item)
        {
            await ProductWarehouseRepository.AddAsync(Item);
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            return await ProductWarehouseRepository.DeleteAsync(ID);
        }

        public async Task<List<ProductWarehouse>> GetAllAsync()
        {
            return await ProductWarehouseRepository.GetAllAsync();
        }

        public async Task<ProductWarehouse> GetByIDAsync(int ID)
        {
            return await ProductWarehouseRepository.GetByIDAsync(ID);
        }

        public Task SaveAsync()
        {
            return ProductWarehouseRepository.SaveAsync();
        }

        public async Task UpdateAsync(ProductWarehouse Item)
        {
            await ProductWarehouseRepository.SaveAsync();
        }
    }
}
