using Nowadays.DTO.Project;

namespace Nowadays.BLL.Abstract
{
    public interface IProjectService
    {
        Task<bool> ProjectAdd(AddNewProjectViewModel project);
        Task<bool> AddEmployeeToProject(ProjectEmployeeViewModel employee);

        Task<bool> ProjectRemove(int entityId);
        Task<bool> ProjectEmployeeRemove(ProjectEmployeeViewModel employee);

        Task<bool> ProjectUpdate(EditProjectViewModel project);

        IEnumerable<ProjectListViewModel> GetAll();

    }
}
