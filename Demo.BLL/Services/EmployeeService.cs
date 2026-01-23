using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo.BLL.Services.DataTransferObjects.Employees;
using Demo.DAL.Entities;
using Demo.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Demo.BLL.Services;

public class EmployeeService(IUnitOfWork unitOfWork, IMapper mapper, IDocumentService documentService) : IEmployeeService
{
    public async Task<int> AddAsync(EmployeeRequest request)
    {
        //var employee = request.ToEntity();
        //return unitOfWork.Employees.AddAsync(employee);
        var employee = mapper.Map<EmployeeRequest, Employee>(request);
        if (request.Image is not null && request.Image.Length > 0)
        {
            var imageName = await documentService.UploadAsync(request.Image, "Images");
            employee.Image = imageName;
        }
        unitOfWork.Employees.Add(employee);
        return await unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await unitOfWork.Employees.GetByIdAsync(id);
        if (employee == null)
            return false;
        unitOfWork.Employees.Delete(employee);
        var result = await unitOfWork.SaveChangesAsync();
        if (result > 0 && employee.Image is not null)
        {
            documentService.Delete(employee.Image, "Images");
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<EmployeeResponse>> GetAllAsync()
    {
        //var employees = unitOfWork.Employees.GetAllAsync(e => new EmployeeResponse
        //{
        //    Age = e.Age,
        //    Email = e.Email,
        //    EmployeeType = e.EmployeeType.ToString(),
        //    Gender = e.Gender.ToString(),
        //    Id = e.Id,
        //    IsActive = e.IsActive,
        //    Name = e.Name,
        //    Department = e.Department.Name,
        //    Salary = e.Salary
        //});
        var employees = await unitOfWork.Employees.GetAllAsQueryable()
            .ProjectTo<EmployeeResponse>(mapper.ConfigurationProvider).ToListAsync();
        return employees;
        //return mapper.Map<IEnumerable<EmployeeResponse>>(employees);
    }

    public async Task<IEnumerable<EmployeeResponse>> GetAllAsync(string searchValue)
    {
        var employees = await unitOfWork.Employees.GetAllAsQueryable()
            .Where(e => e.Name.Contains(searchValue))
            .ProjectTo<EmployeeResponse>(mapper.ConfigurationProvider).ToListAsync();
        return employees;
    }

    public async Task<EmployeeDetailsResponse?> GetByIDAsync(int id)
    {
        var employee = await unitOfWork.Employees.GetByIdAsync(id);
        return mapper.Map<EmployeeDetailsResponse?>(employee);
    }

    public async Task<int> UpdateAsync(EmployeeUpdateRequest request)
    {
        unitOfWork.Employees.Update(mapper.Map<Employee>(request));
        return await unitOfWork.SaveChangesAsync();
    }
}
