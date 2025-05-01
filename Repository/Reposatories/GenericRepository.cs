using InventoryTask.Data;
using InventoryTask.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryTask.Repository.Reposatories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> dbSet;


        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();

        }
        public async Task AddAsync(T Item)
        {
            await dbSet.AddAsync(Item);
        }


        public async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIDAsync(int ID)
        {
            return await dbSet.FindAsync(ID);
        }
        public async Task<bool> DeleteAsync(int ID)
        {
            var item = await GetByIDAsync(ID);
            if (item != null)
            {
                dbSet.Remove(item);
                return true;
            }
            return false;
        }

        public async Task UpdateAsync(T Item)
        {
             dbSet.Update(Item);
            await SaveAsync();

        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
