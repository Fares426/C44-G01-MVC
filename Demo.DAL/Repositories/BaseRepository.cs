using Demo.DAL.Context;

namespace Demo.DAL.Repositories;

public class BaseRepository<TEntity>(CompanyDbContext dbContext) : IRepository<TEntity>
    where TEntity : BaseEntity
{
    protected CompanyDbContext _dbContext = dbContext;
    protected DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();
    public virtual int Add(TEntity entity)
    {
        _dbSet.Add(entity);
        return _dbContext.SaveChanges();
    }

    public virtual int Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
        return _dbContext.SaveChanges();
    }

    public virtual IEnumerable<TEntity> GetAll(bool trackChanges = false)
    {
        return trackChanges ? _dbSet.Where(x => !x.IsDeleted).ToList() : _dbSet.AsNoTracking().Where(x => !x.IsDeleted).ToList();
    }

    public virtual TEntity? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public virtual int Update(TEntity entity)
    {
        _dbSet.Update(entity);
        return _dbContext.SaveChanges();
    }
}
