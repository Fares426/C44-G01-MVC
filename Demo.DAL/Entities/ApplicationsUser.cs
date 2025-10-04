using Microsoft.AspNetCore.Identity;

namespace Demo.DAL.Entities;

public class ApplicationsUser : IdentityUser
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}
