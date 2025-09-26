using Demo.DAL.Context;
using System.Linq.Expressions;

namespace Demo.DAL.Repositories
{
    public class EmployeeRepository(CompanyDbContext dbContext) : BaseRepository<Employee>(dbContext), IEmployeeRepository
    {

        public IEnumerable<Employee> GetAll(string name)
        {
            return _dbSet.Where(e => e.Name == name).ToList();
        }

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<Employee, TResult>> resultSelector)
        {
            return _dbSet.Where(e => !e.IsDeleted).Select(resultSelector).ToList();
        }

        public IQueryable<Employee> GetAllAsQueryable()
        {
            return _dbSet.Where(e => !e.IsDeleted);
        }
    }
}
