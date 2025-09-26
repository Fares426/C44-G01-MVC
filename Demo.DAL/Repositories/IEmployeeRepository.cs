using System.Linq.Expressions;

namespace Demo.DAL.Repositories;

public interface IEmployeeRepository : IRepository<Employee>
{
    IEnumerable<Employee> GetAll(string name);
    IQueryable<Employee> GetAllAsQueryable();
    IEnumerable<TResult> GetAll<TResult>(Expression<Func<Employee, TResult>> resultSelector);
}
