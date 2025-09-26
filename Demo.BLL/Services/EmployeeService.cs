using AutoMapper;
using Demo.BLL.Services.DataTransferObjects.Employees;
using Demo.DAL.Entities;
using Demo.DAL.Repositories;

namespace Demo.BLL.Services;

public class EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) : IEmployeeService
{
    public int Add(EmployeeRequest request)
    {
        //var employee = request.ToEntity();
        //return employeeRepository.Add(employee);
        var employee = mapper.Map<EmployeeRequest, Employee>(request);
        return employeeRepository.Add(employee);
    }

    public bool Delete(int id)
    {
        var employee = employeeRepository.GetById(id);
        if (employee == null)
            return false;
        var result = employeeRepository.Delete(employee);
        return result > 0;
    }

    public IEnumerable<EmployeeResponse> GetAll()
    {
        var employees = employeeRepository.GetAll(e => new EmployeeResponse
        {
            Age = e.Age,
            Email = e.Email,
            EmployeeType = e.EmployeeType.ToString(),
            Gender = e.Gender.ToString(),
            Id = e.Id,
            IsActive = e.IsActive,
            Name = e.Name,
            Salary = e.Salary,
        });
        return employees;
        //return mapper.Map<IEnumerable<EmployeeResponse>>(employees);
    }

    public EmployeeDetailsResponse? GetByID(int id)
    {
        var employee = employeeRepository.GetById(id);
        return mapper.Map<EmployeeDetailsResponse?>(employee);
    }

    public int Update(EmployeeUpdateRequest request)
    {
        return employeeRepository.Update(mapper.Map<Employee>(request));
    }
}
