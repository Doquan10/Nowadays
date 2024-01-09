using Nowadays.DAL.Context;
using Nowadays.DAL.Repositories.Abstractl;
using Nowadays.DAL.Repositories.Concrete;
using Nowadays.DAL.UnitOfWork.Abstract;
using Nowadays.Entity.Concrete;

namespace Nowadays.DAL.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public bool disposed;

        public IGenericRepository<Company> CompanyRepository { get; private set; }
        public IGenericRepository<Employee> EmployeeRepository { get; private set; }
        public IGenericRepository<Issue> IssueRepository { get; private set; }
        public IGenericRepository<Project> ProjectRepository { get; private set; }


        public UnitOfWork(AppDbContext dbContext) {
            
            this.dbContext = dbContext;
            CompanyRepository = new GenericRepository<Company>(dbContext);
            EmployeeRepository = new GenericRepository<Employee>(dbContext);
            IssueRepository = new GenericRepository<Issue>(dbContext);
            ProjectRepository = new GenericRepository<Project>(dbContext);
        }

   

        public async Task CompleteAsync()
        {
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }   
            }
        }

        protected virtual void Clean(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
           Clean(true);
           GC.SuppressFinalize(this);
        }
    }
}
