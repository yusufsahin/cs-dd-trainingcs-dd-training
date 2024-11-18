using OnlineStore.Core.Entities;
using System.Linq.Expressions;
namespace OnlineStore.Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity
    {
        Task<IList<TEntity>> GetAllAsync();
        Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync();
        Task AddAsync(TEntity entity, bool saveChanges = false);
        Task UpdateAsync(TEntity entity, bool saveChanges = false);
        Task DeleteAsync(object id, bool saveChanges = false);
        Task DeleteAsync(TEntity entity, bool saveChanges = false);
        Task CommitAsync();
    }
}