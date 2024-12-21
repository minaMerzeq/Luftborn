using Luftborn.Task.Main.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Luftborn.Task.Main.Infrastructure.Repos
{
    public class Repository<T>(AppDbContext context) : IRepository<T> 
        where T : class
    {
        private readonly AppDbContext _context = context;

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }   
    }
}
