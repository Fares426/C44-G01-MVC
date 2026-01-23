using Demo.BLL.Services.DataTransferObjects;

namespace Demo.BLL.Services;

public interface IDepartmentService
{
    Task<DepartmentDetailsResponse?> GetByIdAsync(int id);
    Task<IEnumerable<DepartmentResponse>> GetAllAsync();
    Task<int> AddAsync(DepartmentRequest request);
    Task<int> UpdateAsync(DepartmentUpdateRequest request);
    Task<bool> DeleteAsync(int id);

}
