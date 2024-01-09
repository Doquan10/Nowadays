using Nowadays.BLL.Abstract;
using Nowadays.DAL.UnitOfWork.Abstract;
using Nowadays.DTO.Report;

namespace Nowadays.BLL.Concrete
{
    public class ReportService : IReportService
    {
        public IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IEnumerable<ReportViewModel> GetAll()
        {
            var result = new ReportViewModel
            {
                TotalCompany = _unitOfWork.CompanyRepository.GetAll().Count().ToString(),
                TotalEmployee = _unitOfWork.EmployeeRepository.GetAll().Count().ToString(),
                TotalProject = _unitOfWork.ProjectRepository.GetAll().Count().ToString(),
                TotalTask = _unitOfWork.IssueRepository.GetAll().Count().ToString(),
            };

            yield return result;

        }
    }
}
