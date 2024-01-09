using Microsoft.AspNetCore.Mvc;
using Nowadays.BLL.Abstract;
using Nowadays.DTO.Issue;

namespace Nowadays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;

        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        [HttpPost("AddIssue")]
        public async Task<IActionResult> AddIssue(AddIssueViewModel issue)
        {
            var result = await _issueService.IssueAdd(issue);
            return Ok(result);
        }


        [HttpPost("AddIssueToEmployee")]
        public async Task<IActionResult> AddIssueToEmployee(IssueEmployeeViewModel issueEmployee)
        {
            var result = await _issueService.AddIssueToEmployee(issueEmployee);
            return Ok(result);
        }

        [HttpPut("EditIssue")]
        public async Task<IActionResult> EditIssue(EditIssueViewModel issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _issueService.IssueUpdate(issue);


            return Ok();
        }

        [HttpDelete("DeleteIssue")]
        public async Task<IActionResult> DeleteIssue(int entityId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _issueService.IssueRemove(entityId);


            return Ok();
        }

        [HttpDelete("DeleteEmployeeToIssue")]
        public async Task<IActionResult> DeleteEmployeeToIssue(IssueEmployeeViewModel issueEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _issueService.IssueEmployeeRemove(issueEmployee);


            return Ok();
        }
    }
}
