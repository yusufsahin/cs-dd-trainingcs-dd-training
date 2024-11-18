using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities;
using System.Linq.Expressions;
namespace OnlineStore.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EfEntityRepositoryBase(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public async Task AddAsync(TEntity entity, bool saveChanges = false)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _dbSet.AddAsync(entity);
            if (saveChanges)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity, bool saveChanges = false)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            if (saveChanges)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(object id, bool saveChanges = false)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) throw new ArgumentException("Entity not found.", nameof(id));

            _dbSet.Remove(entity);

            if (saveChanges)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(TEntity entity, bool saveChanges = false)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _dbSet.Remove(entity);

            if (saveChanges)
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}