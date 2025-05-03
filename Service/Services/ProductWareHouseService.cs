using InventoryTask.Data;
using InventoryTask.Dtos.ProductWareHouse;
using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;
using InventoryTask.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryTask.Service.Services
{
    public class ProductWarehouseService(IGenericRepository<ProductWarehouse> ProductWarehouseRepository ,ApplicationDbContext context) : IProductWareHouseService
    {
        public async Task AddAsync(Dtos.ProductWareHouse.ProductWareHouseDto ProductWarehouse)
        {

            var ProductWarehouseToDb = new ProductWarehouse
            {
                ProductID = ProductWarehouse.ProductID,
                Quantity = ProductWarehouse.Quantity,
                WarehouseID = ProductWarehouse.WarehouseID,
               
            };

            await ProductWarehouseRepository.AddAsync(ProductWarehouseToDb);
            await ProductWarehouseRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = await ProductWarehouseRepository.DeleteAsync(id);
            if (!deleted)
            {
                throw new Exception($"ProductWarehouse with ID {id} not found.");
            }
            await ProductWarehouseRepository.SaveAsync();
        }

        public async Task<List<Dtos.ProductWareHouse.ProductWareHouseDto>> GetAllAsync()
        {
            var ProductWarehousesfromDB = await ProductWarehouseRepository.GetAllAsync();

            var ProductWarehouses = ProductWarehousesfromDB.Select(p => new ProductWareHouseDto
            {
                ProductID = p.ProductID,
                Quantity = p.Quantity,
                WarehouseID = p.WarehouseID
            }).ToList();

            return ProductWarehouses;
        }

        public async Task<Dtos.ProductWareHouse.ProductWareHouseDto> GetByIdAsync(int id)
        {
            var ProductWarehousefromDB = await ProductWarehouseRepository.GetByIDAsync(id);
            if (ProductWarehousefromDB == null) { return null; }
            Dtos.ProductWareHouse.ProductWareHouseDto ProductWarehouse = new Dtos.ProductWareHouse.ProductWareHouseDto
            {
                ProductID = ProductWarehousefromDB.ProductID,
                Quantity = ProductWarehousefromDB.Quantity,
                WarehouseID = ProductWarehousefromDB.WarehouseID,
            };
            return ProductWarehouse;
        }

        public async Task UpdateAsync(Dtos.ProductWareHouse.ProductWareHouseDto ProductWarehouse)
        {
            // Take care of the context
            var ProductWarehouseFromDB =await context.ProductWarehouses.FirstOrDefaultAsync(p => p.WarehouseID == ProductWarehouse.WarehouseID && p.ProductID == ProductWarehouse.ProductID);

            if (ProductWarehouseFromDB == null)
            {
                return;
            }

            ProductWarehouseFromDB.ProductID = ProductWarehouse.ProductID;
            ProductWarehouseFromDB.WarehouseID = ProductWarehouse.WarehouseID;
            ProductWarehouseFromDB.Quantity = ProductWarehouse.Quantity;

            ProductWarehouseRepository.UpdateAsync(ProductWarehouseFromDB);
            await ProductWarehouseRepository.SaveAsync();
        }
    }
}
