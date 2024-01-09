using Nowadays.BLL.Abstract;
using Nowadays.DAL.Context;
using Nowadays.DAL.UnitOfWork.Abstract;
using Nowadays.DTO.Project;
using Nowadays.Entity.Concrete;

namespace Nowadays.BLL.Concrete
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _appDbContext;
        public IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork,
                              AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProjectListViewModel> GetAll()
        {
            var list = _unitOfWork.ProjectRepository.GetAll().Select(a => new ProjectListViewModel
            {
                ProjectName = a.ProjectName,
                ProjectDescription = a.ProjectDescription,
            });
            return list;
        }

        public async Task<bool> ProjectAdd(AddNewProjectViewModel project)
        {
            var checkCompany = _unitOfWork.CompanyRepository.GetAll().Where(a=>a.Id == project.CompanyId).Any();
            if(!checkCompany)
            {
                throw new Exception("Böyle bir şirket yok !");
            }

            var newProject = new Project
            {
                CompanyId = project.CompanyId,
                ProjectName = project.ProjectName,
                ProjectDescription = project.ProjectDescription,

            };
           
            await _unitOfWork.ProjectRepository.InsertAsync(newProject);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<bool> ProjectRemove(int entityId)
        {
            var item = await _unitOfWork.ProjectRepository.GetByIdAsync(entityId);

            await _unitOfWork.ProjectRepository.Delete(item);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> ProjectUpdate(EditProjectViewModel project)
        {
            var editProject = await _unitOfWork.ProjectRepository.GetByIdAsync(project.Id);

            if(editProject is null)
            {
                throw new Exception("Proje bulunamadı");
            }
            editProject.ProjectDescription = project.ProjectDescription;
            editProject.ProjectName = project.ProjectName;

            await _unitOfWork.ProjectRepository.UpdateAsync(editProject);
            await _unitOfWork.CompleteAsync();
            return true;
        }


        public async Task<bool> AddEmployeeToProject(ProjectEmployeeViewModel employee)
        {
            CheckExistUser(employee.EmployeeId, employee.ProjectId);

            var editProject = await _unitOfWork.ProjectRepository.GetByIdAsync(employee.ProjectId);


            var checkEmployee = await _unitOfWork.EmployeeRepository.GetByIdAsync(employee.EmployeeId);

            if (editProject is null)
            {
                throw new Exception("Proje bulunamadı");
            }
            if (checkEmployee is null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }
            if(checkEmployee.CompanyId != editProject.CompanyId)
            {
                throw new Exception("Kullanıcı ve proje aynı şirkete tanımlanmalıdır");
            }

            var employeeProject = new EmployeeProject
            {
                EmployeeId = employee.EmployeeId,
                ProjectId = employee.ProjectId,
                CreatedDate = DateTime.Now,
            };
            _appDbContext.EmployeeProjects.Add(employeeProject);
            _appDbContext.SaveChanges();
          
            return true;
        }

        public async Task<bool> ProjectEmployeeRemove(ProjectEmployeeViewModel employee)
        {
            var existUser = _appDbContext.EmployeeProjects.FirstOrDefault(a => a.ProjectId == employee.ProjectId && a.EmployeeId == employee.EmployeeId);

            _appDbContext.EmployeeProjects.Remove(existUser);
            _appDbContext.SaveChanges();
            return true;
        }

        public bool CheckExistUser(int userId,int projectId) {

            var existUser = _appDbContext.EmployeeProjects.FirstOrDefault(a => a.ProjectId == projectId && a.EmployeeId == userId);

            if (existUser != null)
            {
                throw new Exception("Bu çalışan zaten projeye eklenmiş.");
            }
            return true;
        }

      
    }
}
