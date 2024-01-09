using Nowadays.DAL.Context;
using Nowadays.DAL.Repositories.Abstract;
using Nowadays.Entity.Concrete;

namespace Nowadays.DAL.Repositories.Concrete
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context) { }

    }
}
