using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.DAL.Context.Configurations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .HasColumnType("varchar")
                .IsRequired(false)
                .HasMaxLength(30);


            builder.Property(x => x.PhoneNumber)
                .HasColumnType("varchar")
                .IsRequired(false)
                .HasMaxLength(11);


            builder.Property(x => x.Salary)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.Gender)
                .HasConversion(x => x.ToString(), s => Enum.Parse<Gender>(s));

            builder.Property(x => x.EmployeeType)
                .HasConversion(x => x.ToString(), s => Enum.Parse<EmployeeType>(s));
        }
    }
}
