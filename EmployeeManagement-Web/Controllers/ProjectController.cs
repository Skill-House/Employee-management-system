using EmployeeManagement_Business;
using EmployeeManagement_Repository.Entities;
using Empolyee_Mangement.Data.Models;
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


            public ProjectController(ILogger<ProjectController> logger, ProjectBuisness projectBuisness)
            {
                _logger = logger;
                projectBusiness = projectBuisness;
            }
        [HttpGet("GetAllProjects")]
        public async Task<List<ProjectModel>> GetAllProjects()
        {
            return await projectBusiness.GetAllProjectsAsync();
        }

        [HttpGet("GetProject/{projectId}")]
        public async Task<IActionResult> GetById(int projectId)
        {
            var project = await projectBusiness.GetProjectAsync(projectId);
            return Ok(project);
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
        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteById(int projectId)
        {
            var alumnus = await projectBusiness.DeleteProjectAsync(projectId);
            return Ok(alumnus);
        }
    }
}
