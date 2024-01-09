using Nowadays.DTO.Issue;

namespace Nowadays.BLL.Abstract
{
    public interface IIssueService
    {
        Task<bool> IssueAdd(AddIssueViewModel issue);
        Task<bool> AddIssueToEmployee(IssueEmployeeViewModel issue);
        Task<bool> IssueEmployeeRemove(IssueEmployeeViewModel issue);
        Task<bool> IssueUpdate(EditIssueViewModel issue);
        Task<bool> IssueRemove(int entityId);

    }
}
