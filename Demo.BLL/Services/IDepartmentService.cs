using Demo.BLL.Services.DataTransferObjects;

namespace Demo.BLL.Services;

public interface IDepartmentService
{
    DepartmentDetailsResponse? GetById(int id);
    IEnumerable<DepartmentResponse> GetAll();
    int Add(DepartmentRequest request);
    int Update(DepartmentUpdateRequest request);
    bool Delete(int id);

}
