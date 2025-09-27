using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo.BLL.Services.DataTransferObjects.Employees;
using Demo.DAL.Entities;
using Demo.DAL.Repositories;

namespace Demo.BLL.Services;

public class EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : IEmployeeService
{
    public int Add(EmployeeRequest request)
    {
        //var employee = request.ToEntity();
        //return unitOfWork.Employees.Add(employee);
        var employee = mapper.Map<EmployeeRequest, Employee>(request);
        unitOfWork.Employees.Add(employee);
        return unitOfWork.SaveChanges();
    }

    public bool Delete(int id)
    {
        var employee = unitOfWork.Employees.GetById(id);
        if (employee == null)
            return false;
        unitOfWork.Employees.Delete(employee);
        return unitOfWork.SaveChanges() > 0;
    }

    public IEnumerable<EmployeeResponse> GetAll()
    {
        //var employees = unitOfWork.Employees.GetAll(e => new EmployeeResponse
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
        var employees = unitOfWork.Employees.GetAllAsQueryable()
            .ProjectTo<EmployeeResponse>(mapper.ConfigurationProvider).ToList();
        return employees;
        //return mapper.Map<IEnumerable<EmployeeResponse>>(employees);
    }

    public IEnumerable<EmployeeResponse> GetAll(string searchValue)
    {
        var employees = unitOfWork.Employees.GetAllAsQueryable()
            .Where(e => e.Name.Contains(searchValue))
            .ProjectTo<EmployeeResponse>(mapper.ConfigurationProvider).ToList();
        return employees;
    }

    public EmployeeDetailsResponse? GetByID(int id)
    {
        var employee = unitOfWork.Employees.GetById(id);
        return mapper.Map<EmployeeDetailsResponse?>(employee);
    }

    public int Update(EmployeeUpdateRequest request)
    {
        unitOfWork.Employees.Update(mapper.Map<Employee>(request));
        return unitOfWork.SaveChanges();
    }
}
