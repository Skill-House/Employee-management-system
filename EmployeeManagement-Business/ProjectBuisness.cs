using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Business
{
    public class ProjectBuisness
    {
        private readonly ProjectRepository projectRepository;
        public ProjectBuisness()
        {
            this.projectRepository = new ProjectRepository();
        }
        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await projectRepository.GetAllProjectsAsync();
        }
        public async Task<Project> GetProjectAsync(int ProjectId)
        {
            var pro = await projectRepository.GetById(ProjectId);
            return pro;

        }
        public async Task<HttpStatusCode> SaveProjectAsync(Project project)
        {
            await projectRepository.Create(project);
            return HttpStatusCode.OK;

        }

        public async Task<HttpStatusCode> UpdateProjectAsync(Project project)
        {
            await projectRepository.Update(project);
            return HttpStatusCode.OK;

        }
        public async Task<HttpStatusCode> DeleteProjectAsync(int ProjectId)
        {
            await projectRepository.Delete(ProjectId);
            return HttpStatusCode.OK;
        }
    }
}
