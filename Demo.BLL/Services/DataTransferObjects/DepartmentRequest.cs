namespace Demo.BLL.Services.DataTransferObjects;

public class DepartmentRequest
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
