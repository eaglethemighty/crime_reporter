namespace CrimeService.Data.Repository
{
    public interface IAsyncRepository<TModel>
        where TModel : class
    {
        public Task<List<TModel>> GetAllAsync();
        public Task<List<TModel>> GetAllFilteredByConditionAsync(Func<TModel, bool> condition);
        public Task<TModel?> GetByIdAsync(Guid id);
        public Task AddAsync(TModel entity);
        public Task EditAsync(TModel entity);
        public Task DeleteAsync(TModel entity);
        public Task<bool> SaveAsync();
    }
}
