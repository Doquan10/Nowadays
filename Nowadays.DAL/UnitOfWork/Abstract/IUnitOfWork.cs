using Nowadays.DAL.Repositories.Abstractl;
using Nowadays.Entity.Concrete;

namespace Nowadays.DAL.UnitOfWork.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Company> CompanyRepository { get; }
        IGenericRepository<Employee> EmployeeRepository { get; }
        IGenericRepository<Issue> IssueRepository { get; }
        IGenericRepository<Project> ProjectRepository { get; }
        Task CompleteAsync();
    }
}
 