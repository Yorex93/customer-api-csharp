using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerApi.Models;

namespace CustomerApi.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> SaveAsync(TEntity entityToSave);  
        Task<IEnumerable<TEntity>> FndAllAsync();  
        Task<TEntity> FindByIdAsync(long id);  
        Task DeleteAsync(TEntity entotyToDelete);  
        Task<TEntity> UpdateAsync(TEntity entityToUpdate);
    }
}