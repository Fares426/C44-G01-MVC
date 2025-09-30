namespace Demo.DAL.Repositories;

public interface IRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges = false);
    Task<TEntity?> GetByIdAsync(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
