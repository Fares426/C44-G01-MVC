using Demo.BLL.Services.DataTransferObjects;
using Demo.DAL.Entities;

namespace Demo.BLL.Services;

public interface IDepartmentService
{
    DepartmentDetailsResponse? GetDepartmentById(int id);
    IEnumerable<DepartmentResponse> GetAllDepartments();
    int AddDepartment(DepartmentRequest request);
    int UpdateDepartment(DepartmentUpdateRequest request);
    bool DeleteDepartment(int id);

}
