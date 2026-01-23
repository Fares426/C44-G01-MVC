using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Demo.DAL.Context;

public class CompanyDbContext(DbContextOptions<CompanyDbContext> options)
    : IdentityDbContext<ApplicationsUser>(options)
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationsUser>(builder =>
        {
            builder.Property(u => u.FirstName)
            .HasColumnType("varChar")
            .HasMaxLength(256);

            builder.Property(u => u.LastName)
            .HasColumnType("varChar")
            .HasMaxLength(256);
        });
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyDbContext).Assembly);
    }
}
