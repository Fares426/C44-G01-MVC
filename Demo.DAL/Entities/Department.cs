namespace Demo.DAL.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } //User Input
    public ICollection<Employee> Employees { get; set; } = [];
}
