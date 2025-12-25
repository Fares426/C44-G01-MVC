using Demo.DAL.Context;

namespace Demo.DAL.Repositories;

public class BaseRepository<TEntity>(CompanyDbContext dbContext) : IRepository<TEntity>
    where TEntity : BaseEntity
{
    protected CompanyDbContext _dbContext = dbContext;
    protected DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();
    public virtual void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false)
    {
        return trackChanges ? await _dbSet.Where(x => !x.IsDeleted).ToListAsync() : await _dbSet.AsNoTracking().Where(x => !x.IsDeleted).ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }
}
