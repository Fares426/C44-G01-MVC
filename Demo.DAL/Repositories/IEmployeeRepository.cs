using System.Linq.Expressions;

namespace Demo.DAL.Repositories;

public interface IEmployeeRepository : IRepository<Employee>
{
    IEnumerable<Employee> GetAll(string name);
    IQueryable<Employee> GetAllAsQueryable();
    Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<Employee, TResult>> resultSelector,
            Expression<Func<Employee, bool>>? predicate = null);
}
