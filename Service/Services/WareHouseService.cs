using InventoryTask.Dtos.WareHouse;
using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;
using InventoryTask.Service.Interfaces;

namespace InventoryTask.Service.Services
{
    public class WarehouseService(IGenericRepository<Warehouse> WarehouseRepository) : IWareHouseService
    {
        public async Task AddAsync(WareHouseRequest Warehouse)
        {

            var WarehouseToDb = new Warehouse
            {
                Name = Warehouse.Name,
                Location = Warehouse.Location,

            };

            await WarehouseRepository.AddAsync(WarehouseToDb);
            await WarehouseRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = await WarehouseRepository.DeleteAsync(id);
            if (!deleted)
            {
                throw new Exception($"Warehouse with ID {id} not found.");
            }
            await WarehouseRepository.SaveAsync();
        }

        public async Task<List<WareHouseResponce>> GetAllAsync()
        {
            var WarehousesfromDB = await WarehouseRepository.GetAllAsync();

            var Warehouses = WarehousesfromDB.Select(p => new WareHouseResponce
            {
                ID = p.ID,
                Name = p.Name,
                Location = p.Location
            }).ToList();

            return Warehouses;
        }

        public async Task<WareHouseResponce> GetByIdAsync(int id)
        {
            var WarehousefromDB = await WarehouseRepository.GetByIDAsync(id);
            if (WarehousefromDB == null) { return null; }
            WareHouseResponce Warehouse = new WareHouseResponce
            {
                ID = WarehousefromDB.ID,
                Name = WarehousefromDB.Name,
                Location = WarehousefromDB.Location
            };
            return Warehouse;
        }

        public async Task UpdateAsync(WareHouseResponce Warehouse)
        {
            var WarehouseFromDB = await WarehouseRepository.GetByIDAsync(Warehouse.ID);

            if (WarehouseFromDB == null)
            {
                return;
            }

            WarehouseFromDB.Name = Warehouse.Name;
            WarehouseFromDB.Location = Warehouse.Location;

            WarehouseRepository.UpdateAsync(WarehouseFromDB);
            await WarehouseRepository.SaveAsync();
        }
    }
}
