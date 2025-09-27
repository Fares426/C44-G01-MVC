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

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<Employee, TResult>> resultSelector,
            Expression<Func<Employee, bool>>? predicate = null)
        {
            if (predicate is null)
                return _dbSet.Where(e => !e.IsDeleted).Select(resultSelector).ToList();

            return _dbSet.Where(e => !e.IsDeleted).Where(predicate).Select(resultSelector).ToList();
        }

        public IQueryable<Employee> GetAllAsQueryable()
        {
            return _dbSet.Where(e => !e.IsDeleted);
        }

        public override Employee? GetById(int id)
        {
            return _dbSet.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
        }
    }
}
