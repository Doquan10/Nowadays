using Microsoft.AspNetCore.Mvc;
using Nowadays.BLL.Abstract;
using Nowadays.DTO.Project;

namespace Nowadays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("GetAllProjects")]
        public IActionResult Get()
        {
            var projects = _projectService.GetAll();

            return Ok(projects);
        }

        [HttpPost("AddProject")]
        public async Task<IActionResult> AddProject(AddNewProjectViewModel company)
        {
            var result = await _projectService.ProjectAdd(company);
            return Ok(result);
        }

        [HttpDelete("DeleteProject")]
        public async Task<IActionResult> DeleteProject(int entityId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _projectService.ProjectRemove(entityId);


            return Ok();
        }

        [HttpPut("EditProject")]
        public async Task<IActionResult> EditProject(EditProjectViewModel project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _projectService.ProjectUpdate(project);


            return Ok();
        }

        [HttpPost("AddEmployeeToProject")]
        public async Task<IActionResult> AddEmployeeToProject(ProjectEmployeeViewModel employee)
        {
            var result = await _projectService.AddEmployeeToProject(employee);
            return Ok(result);
        }

        [HttpDelete("DeleteEmployeeToProject")]
        public async Task<IActionResult> DeleteEmployeeToProject(ProjectEmployeeViewModel employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _projectService.ProjectEmployeeRemove(employee);


            return Ok();
        }
    }
}
