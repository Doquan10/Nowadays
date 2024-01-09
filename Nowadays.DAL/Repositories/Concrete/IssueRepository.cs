using Nowadays.DAL.Context;
using Nowadays.DAL.Repositories.Abstract;
using Nowadays.Entity.Concrete;

namespace Nowadays.DAL.Repositories.Concrete
{
    public class IssueRepository : GenericRepository<Issue>, IIssueRepository
    {
        public IssueRepository(AppDbContext context) : base(context) { }

    }
}
