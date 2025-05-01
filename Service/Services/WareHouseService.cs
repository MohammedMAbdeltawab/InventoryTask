using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;
using InventoryTask.Service.Interfaces;

namespace InventoryTask.Service.Services
{
    public class WareHouseService(IGenericRepository<Warehouse> WareHouseRepository) : IWareHouseService
    {

        public async Task AddAsync(Warehouse Item)
        {
            await WareHouseRepository.AddAsync(Item);
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            return await WareHouseRepository.DeleteAsync(ID);
        }

        public async Task<List<Warehouse>> GetAllAsync()
        {
            return await WareHouseRepository.GetAllAsync();
        }

        public async Task<Warehouse> GetByIDAsync(int ID)
        {
            return await WareHouseRepository.GetByIDAsync(ID);
        }

        public Task SaveAsync()
        {
            return WareHouseRepository.SaveAsync();
        }

        public async Task UpdateAsync(Warehouse Item)
        {
            await WareHouseRepository.SaveAsync();
        }
    }
}
