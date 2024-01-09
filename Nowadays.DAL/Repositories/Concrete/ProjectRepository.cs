
using Nowadays.DAL.Context;
using Nowadays.DAL.Repositories.Abstract;
using Nowadays.Entity.Concrete;

namespace Nowadays.DAL.Repositories.Concrete
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context) { }

    }
}
