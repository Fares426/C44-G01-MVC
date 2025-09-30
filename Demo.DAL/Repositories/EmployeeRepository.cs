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

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<Employee, TResult>> resultSelector,
            Expression<Func<Employee, bool>>? predicate = null)
        {
            if (predicate is null)
                return await _dbSet.Where(e => !e.IsDeleted).Select(resultSelector).ToListAsync();

            return await _dbSet.Where(e => !e.IsDeleted).Where(predicate).Select(resultSelector).ToListAsync();
        }

        public IQueryable<Employee> GetAllAsQueryable()
        {
            return _dbSet.Where(e => !e.IsDeleted);
        }

        public override async Task<Employee?> GetByIdAsync(int id)
        {
            return await _dbSet.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
