using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.DAL.Context.Configurations;

internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(d=>d.Id)
            .UseIdentityColumn(10,10);


        builder.Property(d => d.Name)
            .IsRequired(true)
            .HasMaxLength(50)
            .HasColumnType("varChar");


        builder.Property(d => d.Description)
            .HasMaxLength(50)
            .HasColumnType("varChar");


        builder.Property(d => d.Code)
            .IsRequired(true)
            .HasMaxLength(50)
            .HasColumnType("varChar");

        builder.Property(d => d.CreatedOn)
            .HasDefaultValueSql("GETDATE()");

    }
}
