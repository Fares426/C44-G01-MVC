using Demo.DAL.Context;

namespace Demo.DAL.Repositories;

public class UnitOfWork(CompanyDbContext dbContext, IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
    : IUnitOfWork
{
    public IEmployeeRepository Employees => employeeRepository;

    public IDepartmentRepository Departments => departmentRepository;

    public int SaveChanges()
    {
        return dbContext.SaveChanges();
    }
}
