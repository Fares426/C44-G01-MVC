namespace Demo.DAL.Repositories;

public interface IUnitOfWork
{
    IEmployeeRepository Employees { get; }
    IDepartmentRepository Departments { get; }
    Task<int> SaveChangesAsync();
}
