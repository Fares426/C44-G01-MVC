using Demo.BLL.Services.DataTransferObjects;
using Demo.DAL.Repositories;

namespace Demo.BLL.Services;

public class DepartmentService(IUnitOfWork unitOfWork) : IDepartmentService
{

    public async Task<int> AddAsync(DepartmentRequest request)
    {
        var department = request.ToEntity();
        unitOfWork.Departments.Add(department);
        return await unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var department = await unitOfWork.Departments.GetByIdAsync(id);
        if (department == null)
            return false;
        unitOfWork.Departments.Delete(department);
        return await unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<DepartmentResponse>> GetAllAsync()
    {
        var departments = await unitOfWork.Departments.GetAllAsync();
        return departments.Select(d => d.ToResponse());
    }

    public async Task<DepartmentDetailsResponse?> GetByIdAsync(int id)
    {
        return (await unitOfWork.Departments.GetByIdAsync(id))?.ToDetailsResponse();
    }

    public async Task<int> UpdateAsync(DepartmentUpdateRequest request)
    {
        unitOfWork.Departments.Update(request.ToEntity());
        return await unitOfWork.SaveChangesAsync();
    }
}
