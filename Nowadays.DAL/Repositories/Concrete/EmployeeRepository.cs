using Nowadays.DAL.Context;
using Nowadays.DAL.Repositories.Abstract;
using Nowadays.Entity.Concrete;

namespace Nowadays.DAL.Repositories.Concrete
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context) { }

    }
}
