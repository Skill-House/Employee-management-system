using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using Empolyee_Mangement.Data.Models;
using System.Net;

namespace EmployeeManagement_Business
{
    public class ProjectBuisness
    {
        private readonly ProjectRepository projectRepository;
        public ProjectBuisness(ProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }
        //public async Task<List<Project>> GetAllProjectsAsync()
        //{
        //    return await projectRepository.GetAllProjectsAsync();
        //}
        public async Task<List<ProjectModel>> GetAllProjectsAsync()
        {
            var employeeViewModelList = new List<ProjectModel>();
            var employeeList = await projectRepository.GetAllProjectsAsync();
            foreach (var employee in employeeList)
            {
                employeeViewModelList.Add(new ProjectModel
                {
                    ProjectId = employee.ProjectId,
                    ProjectName = employee.ProjectName,
                    ProjectDescription = employee.ProjectDescription,
                    Projectduration = employee.Projectduration,
                });
            }
            return employeeViewModelList;
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
