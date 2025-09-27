using Demo.BLL.Services.DataTransferObjects;
using Demo.DAL.Repositories;

namespace Demo.BLL.Services;

public class DepartmentService(IUnitOfWork unitOfWork) : IDepartmentService
{

    public int Add(DepartmentRequest request)
    {
        var department = request.ToEntity();
        unitOfWork.Departments.Add(department);
        return unitOfWork.SaveChanges();
    }

    public bool Delete(int id)
    {
        var department = unitOfWork.Departments.GetById(id);
        if (department == null)
            return false;
        unitOfWork.Departments.Delete(department);
        return unitOfWork.SaveChanges() > 0;
    }

    public IEnumerable<DepartmentResponse> GetAll()
    {
        var departments = unitOfWork.Departments.GetAll();
        return departments.Select(d => d.ToResponse());
    }

    public DepartmentDetailsResponse? GetById(int id)
    {
        return unitOfWork.Departments.GetById(id)?.ToDetailsResponse();
    }

    public int Update(DepartmentUpdateRequest request)
    {
        unitOfWork.Departments.Update(request.ToEntity());
        return unitOfWork.SaveChanges();
    }
}
