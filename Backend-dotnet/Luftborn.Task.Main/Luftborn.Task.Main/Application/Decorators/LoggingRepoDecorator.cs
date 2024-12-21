using Luftborn.Task.Main.Domain.Interfaces;

namespace Luftborn.Task.Main.Application.Decorators
{
    public class LoggingRepoDecorator<T>(IRepository<T> repository, ILogger<LoggingRepoDecorator<T>> logger) : IRepository<T> where T : class
    {
        private readonly IRepository<T> _innerRepository = repository;
        private readonly ILogger<LoggingRepoDecorator<T>> _logger = logger;

        public async Task<List<T>> GetAllAsync()
        {
            _logger.LogInformation($"Getting all {typeof(T).Name}s");
            return await _innerRepository.GetAllAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Getting {typeof(T).Name} with id {id}");
            return await _innerRepository.GetByIdAsync(id);
        }

        public void Add(T entity)
        {
            _logger.LogInformation($"Adding {typeof(T).Name}");
            _innerRepository.Add(entity);
        }

        public void Update(T entity)
        {
            _logger.LogInformation($"Updating {typeof(T).Name}");
            _innerRepository.Update(entity);
        }

        public void Delete(T entity)
        {
            Console.WriteLine($"Deleting {typeof(T).Name}");
            _innerRepository.Delete(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            Console.WriteLine($"Saving changes for {typeof(T).Name}");
            return await _innerRepository.SaveChangesAsync();
        }   
    }
}
