namespace InventoryTask.Repository.Interfaces
{
    public interface IGenericRepository<T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIDAsync(int ID);
        public Task AddAsync(T Item);
        public void UpdateAsync(T Item);
        public Task<bool> DeleteAsync(int ID);
        public Task SaveAsync();
    }
}
