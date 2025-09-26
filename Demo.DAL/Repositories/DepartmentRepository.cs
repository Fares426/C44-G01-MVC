using Demo.DAL.Context;

namespace Demo.DAL.Repositories;

public class DepartmentRepository(CompanyDbContext dbContext) : BaseRepository<Department>(dbContext), IDepartmentRepository
{

}
