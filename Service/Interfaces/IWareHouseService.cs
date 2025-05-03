using InventoryTask.Dtos.Product;
using InventoryTask.Dtos.WareHouse;
using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;

namespace InventoryTask.Service.Interfaces
{
    public interface IWareHouseService 
    {
        public Task<List<WareHouseResponce>> GetAllAsync();
        public Task<WareHouseResponce?> GetByIdAsync(int id);
        public Task AddAsync(WareHouseRequest product);
        public Task UpdateAsync(WareHouseResponce product);
        public Task DeleteAsync(int id);
    }
}
