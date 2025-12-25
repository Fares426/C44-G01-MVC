using Demo.DAL.Entities;

namespace Demo.BLL.Services.DataTransferObjects;

public static class DepartmentFactory
{
    public static DepartmentResponse ToResponse(this Department department) => new()
    {
        Id = department.Id,
        Name = department.Name,
        Description = department.Description,
        CreatedAt = DateOnly.FromDateTime(department.CreatedOn),
        Code = department.Code
    };
    public static DepartmentDetailsResponse ToDetailsResponse(this Department department) => new()
    {
        Id = department.Id,
        Name = department.Name,
        Description = department.Description,
        CreatedBy = department.CreatedBy,
        CreatedOn = department.CreatedOn,
        IsDeleted = department.IsDeleted,
        Code = department.Code,
        LastModifiedBy = department.LastModifiedBy,
        LastModifiedOn = department.LastModifiedOn,
        CreatedAt = department.CreatedAt,
    };
    public static Department ToEntity(this DepartmentRequest departmentRequest) => new()
    {
        Name = departmentRequest.Name,
        Description = departmentRequest.Description,
        Code = departmentRequest.Code,
        CreatedAt = departmentRequest.CreatedAt,
    };
    public static Department ToEntity(this DepartmentUpdateRequest departmentRequest) => new()
    {
        Id = departmentRequest.Id,
        Name = departmentRequest.Name,
        Description = departmentRequest.Description,
        Code = departmentRequest.Code,
        CreatedAt = departmentRequest.CreatedAt
    };
    public static DepartmentUpdateRequest ToUpdateRequest(this DepartmentDetailsResponse departmentRequest) => new()
    {
        Id = departmentRequest.Id,
        Name = departmentRequest.Name,
        Description = departmentRequest.Description,
        Code = departmentRequest.Code,
        CreatedAt = departmentRequest.CreatedAt,
    };
    public static DepartmentRequest ToRequest(this DepartmentUpdateRequest departmentRequest) => new()
    {
        Name = departmentRequest.Name,
        Description = departmentRequest.Description,
        Code = departmentRequest.Code
    };

}
