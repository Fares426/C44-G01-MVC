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

    public virtual IEnumerable<TEntity> GetAll(bool trackChanges = false)
    {
        return trackChanges ? _dbSet.Where(x => !x.IsDeleted).ToList() : _dbSet.AsNoTracking().Where(x => !x.IsDeleted).ToList();
    }

    public virtual TEntity? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public virtual void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }
}
