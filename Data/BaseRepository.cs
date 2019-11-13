using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Data
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly CustomerDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(CustomerDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }
        public async Task DeleteAsync(TEntity entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> FndAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> FindByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> SaveAsync(TEntity entityToSave)
        {
            await _dbSet.AddAsync(entityToSave);
            await _context.SaveChangesAsync();
            return entityToSave;
        }

        public async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entityToUpdate;
        }
    }
}