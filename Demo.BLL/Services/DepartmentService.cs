using Demo.BLL.Services.DataTransferObjects;
using Demo.DAL.Repositories;

namespace Demo.BLL.Services;

public class DepartmentService : IDepartmentService
{
    private IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public int Add(DepartmentRequest request)
    {
        var department = request.ToEntity();
        return _departmentRepository.Add(department);
    }

    public bool Delete(int id)
    {
        var department = _departmentRepository.GetById(id);
        if (department == null)
            return false;
        var result = _departmentRepository.Delete(department);
        return result > 0;
    }

    public IEnumerable<DepartmentResponse> GetAll()
    {
        var departments = _departmentRepository.GetAll();
        return departments.Select(d => d.ToResponse());
    }

    public DepartmentDetailsResponse? GetById(int id)
    {
        return _departmentRepository.GetById(id)?.ToDetailsResponse();
    }

    public int Update(DepartmentUpdateRequest request)
    {
        return _departmentRepository.Update(request.ToEntity());
    }
}
