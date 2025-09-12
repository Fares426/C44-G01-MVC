namespace Demo.DAL.Repositories;

public interface IDepartmentRepository
{
    IEnumerable<Department> GetAllDepartments(bool trackChanges = false);
    Department? GetDepartmentById(int id);
    int AddDepartment(Department department);
    int UpdateDepartment(Department department);
    int DeleteDepartment(Department department);
}
