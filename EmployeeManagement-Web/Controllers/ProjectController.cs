using EmployeeManagement_Business;
using EmployeeManagement_Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ApiBaseController
    {


            private readonly ILogger<ProjectController> _logger;
            private readonly ProjectBuisness projectBusiness;


            public ProjectController(ILogger<ProjectController> logger)
            {
                _logger = logger;
                projectBusiness = new ProjectBuisness();
            }
        [HttpGet("GetAllProjects")]
        public async Task<List<Project>> GetAllProjects()
        {
            return await projectBusiness.GetAllProjectsAsync();
        }

        [HttpGet("GetProject")]
        public async Task<IActionResult> GetById(int projectId)
        {
            var alumnus = await projectBusiness.GetProjectAsync(projectId);
            return Ok(alumnus);
        }

        [HttpPost("SaveProject")]
        public async Task<HttpStatusCode> SaveProject(Project project)
        {
            return await projectBusiness.SaveProjectAsync(project);
        }

        [HttpPut("UpdateProject")]
        public async Task<HttpStatusCode> UpdateProject(Project project)
        {
            return await projectBusiness.UpdateProjectAsync(project);
        }
        [HttpDelete("DeleteProject")]
        public async Task<IActionResult> DeleteById(int projectId)
        {
            var alumnus = await projectBusiness.DeleteProjectAsync(projectId);
            return Ok(alumnus);
        }
    }
}
