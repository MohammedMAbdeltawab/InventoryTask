using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;
using InventoryTask.Service.Interfaces;

namespace InventoryTask.Service.Services
{
    public class CategoryService(IGenericRepository<Category> CategoryRepository) : ICategoryService
    {

        public async Task AddAsync(Category Item)
        {
            await CategoryRepository.AddAsync(Item);
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            return await CategoryRepository.DeleteAsync(ID);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await CategoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIDAsync(int ID)
        {
            return await CategoryRepository.GetByIDAsync(ID);
        }

        public Task SaveAsync()
        {
            return CategoryRepository.SaveAsync();
        }

        public async Task UpdateAsync(Category Item)
        {
            await CategoryRepository.SaveAsync();
        }
    }
}
