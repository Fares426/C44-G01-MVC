namespace Demo.DAL.Repositories;

public interface IRepository<TEntity>
    where TEntity : BaseEntity
{
    IEnumerable<TEntity> GetAll(bool trackChanges = false);
    TEntity? GetById(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
