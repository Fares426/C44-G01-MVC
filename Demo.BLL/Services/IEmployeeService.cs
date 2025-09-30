using Demo.BLL.Services.DataTransferObjects.Employees;

namespace Demo.BLL.Services;

public interface IEmployeeService
{
    Task<EmployeeDetailsResponse?> GetByIDAsync(int id);
    Task<IEnumerable<EmployeeResponse>> GetAllAsync();
    Task<IEnumerable<EmployeeResponse>> GetAllAsync(string searchValue);
    Task<int> AddAsync(EmployeeRequest request);
    Task<int> UpdateAsync(EmployeeUpdateRequest request);
    Task<bool> DeleteAsync(int id);
}
