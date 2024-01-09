using Nowadays.DTO.Report;

namespace Nowadays.BLL.Abstract
{
    public interface IReportService
    {
        IEnumerable<ReportViewModel> GetAll();
    }
}
