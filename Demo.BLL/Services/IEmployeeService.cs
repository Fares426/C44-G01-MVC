using Demo.BLL.Services.DataTransferObjects.Employees;

namespace Demo.BLL.Services;

public interface IEmployeeService
{
    EmployeeDetailsResponse? GetByID(int id);
    IEnumerable<EmployeeResponse> GetAll();
    IEnumerable<EmployeeResponse> GetAll(string searchValue);
    int Add(EmployeeRequest request);
    int Update(EmployeeUpdateRequest request);
    bool Delete(int id);
}
