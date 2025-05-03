using InventoryTask.Dtos.Product;
using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;
using InventoryTask.Service.Interfaces;

namespace InventoryTask.Service.Services
{
    public class ProductService(IGenericRepository<Product> ProductRepository) : IProductService
    {
        public async Task AddAsync(ProductDto product)
        {

            var productToDb = new Product
            {
                Name = product.Name,
                Description = product.Description,
                price = product.Price,
                LowStockThreshold = product.LowStockThreshold,
                CategoryID = product.CategoryID
            };

            await ProductRepository.AddAsync(productToDb);
            await ProductRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleted = await ProductRepository.DeleteAsync(id);
            if (!deleted)
            {
                throw new Exception($"Product with ID {id} not found.");
            }
            await ProductRepository.SaveAsync();
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var productsfromDB = await ProductRepository.GetAllAsync();

            var products = productsfromDB.Select(p => new ProductDto
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.price,
                LowStockThreshold = p.LowStockThreshold,
                CategoryID = p.CategoryID
            }).ToList();

            return products;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var productfromDB = await ProductRepository.GetByIDAsync(id);
            if (productfromDB == null) { return null; }
            ProductDto product = new ProductDto
            {
                Name = productfromDB.Name,
                Description = productfromDB.Description,
                Price = productfromDB.price,
                LowStockThreshold = productfromDB.LowStockThreshold,
                CategoryID = productfromDB.CategoryID
            };
            return product;
        }

        public async Task UpdateAsync(ProductDto product)
        {
            var productFromDB = await ProductRepository.GetByIDAsync(product.ID);

            if (productFromDB == null)
            {
                return;
            }

            productFromDB.Name = product.Name;
            productFromDB.price = product.Price;
            productFromDB.Description = product.Description;
            productFromDB.LowStockThreshold = product.LowStockThreshold;
            productFromDB.CategoryID = product.CategoryID;

            ProductRepository.UpdateAsync(productFromDB);
            await ProductRepository.SaveAsync();
        }
    }
}
