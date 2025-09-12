using Demo.BLL.Services.DataTransferObjects;
using Demo.DAL.Entities;
using Demo.DAL.Repositories;

namespace Demo.BLL.Services;

public class DepartmentService : IDepartmentService
{
    private IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public int AddDepartment(DepartmentRequest request)
    {
        var department = request.ToEntity();
        return _departmentRepository.AddDepartment(department);
    }

    public bool DeleteDepartment(int id)
    {
        var department = _departmentRepository.GetDepartmentById(id);
        if (department == null)
            return false;
        var result = _departmentRepository.DeleteDepartment(department);
        return result > 0;
    }

    public IEnumerable<DepartmentResponse> GetAllDepartments()
    {
        var departments = _departmentRepository.GetAllDepartments();
        return departments.Select(d => d.ToResponse());
    }

    public DepartmentDetailsResponse? GetDepartmentById(int id)
    {
        return _departmentRepository.GetDepartmentById(id)?.ToDetailsResponse();
    }

    public int UpdateDepartment(DepartmentUpdateRequest request)
    {
        return _departmentRepository.UpdateDepartment(request.ToEntity());
    }
}
