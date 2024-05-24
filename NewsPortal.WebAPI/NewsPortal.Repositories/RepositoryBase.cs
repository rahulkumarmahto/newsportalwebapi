using Microsoft.EntityFrameworkCore;
using NewsPortal.Repositories.Data;

namespace NewsPortal.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity request);
        Task UpdateAsync(TEntity request);
        Task DeleteByIdAsync(int id);
    }

    public class RepositoryBase<TEntity>
        where TEntity : class
    {
        private readonly NewsPortalWebAPIContext _context;
        private readonly DbSet<TEntity> dbSet;

        protected RepositoryBase(NewsPortalWebAPIContext context)
        {
            this._context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await dbSet.FindAsync(id).ConfigureAwait(false);
            return entity;
        }
        public async Task AddAsync(TEntity request)
        {
           await dbSet.AddAsync(request).ConfigureAwait(false);
           await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TEntity request)
        {
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            
            if (entity == null)
                return;

            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
