using Demo.DAL.Context;

namespace Demo.DAL.Repositories;

public class DepartmentRepository(CompanyDbContext dbContext) : IDepartmentRepository
{
    private CompanyDbContext _dbContext = dbContext;
    private DbSet<Department> _departments = dbContext.Departments;
    public int AddDepartment(Department department)
    {
        _departments.Add(department);
        return _dbContext.SaveChanges();
    }

    public int DeleteDepartment(Department department)
    {
        _departments.Remove(department);
        return _dbContext.SaveChanges();
    }

    public IEnumerable<Department> GetAllDepartments(bool trackChanges = false)
    {
        return trackChanges ? _departments.ToList() : _departments.AsNoTracking().ToList();
    }

    public Department? GetDepartmentById(int id)
    {
        return _departments.Find(id);
    }

    public int UpdateDepartment(Department department)
    {
        _departments.Update(department);
        return _dbContext.SaveChanges();
    }
}
