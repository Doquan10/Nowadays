using Nowadays.BLL.Abstract;
using Nowadays.DAL.Context;
using Nowadays.DAL.UnitOfWork.Abstract;
using Nowadays.DTO.Issue;
using Nowadays.Entity.Concrete;

namespace Nowadays.BLL.Concrete
{
    public class IssueService : IIssueService
    {
        private readonly AppDbContext _appDbContext;
        public IUnitOfWork _unitOfWork;
        public IssueService(IUnitOfWork unitOfWork,
                            AppDbContext appDbContext)
        {
            _unitOfWork = unitOfWork;
            _appDbContext = appDbContext;
        }


        public async Task<bool> IssueAdd(AddIssueViewModel issue)
        {
            var existProject =await _unitOfWork.ProjectRepository.GetByIdAsync(issue.ProjectId);
            if (existProject == null)
            {
                throw new Exception("Proje Bulunamadı");
            }

            var newIssue = new Issue
            {
                ProjectId = issue.ProjectId,
                IssueName = issue.IssueName
            };

            await _unitOfWork.IssueRepository.InsertAsync(newIssue);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> IssueUpdate(EditIssueViewModel issue)
        {
            var editIssue = await _unitOfWork.IssueRepository.GetByIdAsync(issue.Id);

            if (editIssue is null)
            {
                throw new Exception("Görev bulunamadı");
            }
            editIssue.IssueName = issue.IssueName;

            await _unitOfWork.IssueRepository.UpdateAsync(editIssue);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> IssueRemove(int entityId)
        {
            var item = await _unitOfWork.IssueRepository.GetByIdAsync(entityId);

            await _unitOfWork.IssueRepository.Delete(item);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> AddIssueToEmployee(IssueEmployeeViewModel issue)
        {
            var getProjectId = await _unitOfWork.IssueRepository.GetByIdAsync(issue.IssueId);
            var getUser = await _unitOfWork.EmployeeRepository.GetByIdAsync(issue.EmployeeId);

            bool isSigned = _appDbContext.EmployeeProjects.Any(a=>a.ProjectId == getProjectId.ProjectId && a.EmployeeId == issue.EmployeeId);//Seçilen kişi proje çalışanı olarak tanımlanmış mı ?
           
            if(isSigned)
            {
                var newIssue = new IssueEmployee
                {
                    IssueId = issue.IssueId,
                    EmployeeId = issue.EmployeeId,
                    CreatedDate = DateTime.UtcNow,
                };

                _appDbContext.Add(newIssue);
                _appDbContext.SaveChanges();

                return true;
            }
            throw new Exception("İlgili projeye bu çalışan tanımlanmamış");
           

        }
        public async Task<bool> IssueEmployeeRemove(IssueEmployeeViewModel issue)
        {
            var existIssue = _appDbContext.IssueEmployees.FirstOrDefault(a => a.IssueId == issue.IssueId && a.EmployeeId == issue.EmployeeId);

            _appDbContext.IssueEmployees.Remove(existIssue);
            _appDbContext.SaveChanges();
            return true;
        }
       
    }
}
