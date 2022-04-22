using CrimeService.Data.DAL;

namespace CrimeService.Data.Repository
{
    public class EfCoreRepository<TModel> : IAsyncRepository<TModel>
        where TModel : class
    {
        private readonly DbAccess _dbAccess;
        private readonly ILogger _logger;
        public EfCoreRepository(DbAccess dbAccess, ILogger logger)
        {
            _dbAccess = dbAccess ?? throw new ArgumentNullException(nameof(dbAccess));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public Task AddAsync(TModel entity)
        {
            return Task.Run(() =>
            {
                _dbAccess.Set<TModel>().Add(entity);
                _logger.LogInformation($"Added entity of type {nameof(TModel)}");
            });
        }

        public Task DeleteAsync(TModel entity)
        {
            return Task.Run(() =>
            {
                _dbAccess.Set<TModel>().Remove(entity);
                _logger.LogInformation($"Deleted entity of type {nameof(TModel)}");
            });
        }

        public Task EditAsync(TModel entity)
        {
            return Task.Run(() =>
            {
                _dbAccess.Set<TModel>().Update(entity);
                _logger.LogInformation($"Updated entity of type {nameof(TModel)}. New models state: {@entity}", entity);
            });
        }

        public Task<List<TModel>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                var AllModels = _dbAccess.Set<TModel>().ToList();
                _logger.LogInformation($"Retrieved all entities of type {nameof(TModel)}. Count: {AllModels.Count}");
                return AllModels;
            });
        }

        public Task<List<TModel>> GetAllFilteredByConditionAsync(Func<TModel, bool> condition)
        {
            return Task.Run(() =>
            {
                var AllModels = _dbAccess.Set<TModel>().Where(condition).ToList();
                _logger.LogInformation($"Retrieved all entities of type {nameof(TModel)} filtered by condition. Count: {AllModels.Count}");
                return AllModels;
            });
        }

        public Task<TModel?> GetByIdAsync(Guid id)
        {
            return Task.Run(() =>
            {
                var ModelWithId = _dbAccess.Set<TModel>().Find(id);
                _logger.LogInformation(ModelWithId is null ? $"Retrieved no model with id: {id}" : $"Retrieved a model with id: {id}");
                return ModelWithId;
            });
        }

        public Task<bool> SaveAsync()
        {
            return Task.Run(() =>
            {
                int ChangesOnSave = _dbAccess.SaveChanges();
                _logger.LogInformation($"{ChangesOnSave} changes in the database on save");
                return ChangesOnSave > 0;
            });
        }
    }
}
