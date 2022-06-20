using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository
{
    public class ProjectRepository
    {
        private readonly EmployeeManagementContext dbContext;
        public ProjectRepository()
        {
            this.dbContext = new EmployeeManagementContext();
        }
        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return dbContext.Projects.ToList();
        }
        public async Task Create(Project project)
        {
            dbContext.Projects.Add(project);
            await dbContext.SaveChangesAsync();
        }
        public async Task<Project> GetById(int ProjectId)
        {
            var pro = dbContext.Projects.FirstOrDefault(e => e.ProjectId == ProjectId);
            return pro;
        }
        public async Task Update(Project project)
        {
            var existingPro = dbContext.Projects.Where(h => h.ProjectId == project.ProjectId).FirstOrDefault();
            if (existingPro != null)
            {
                existingPro.ProjectName = project.ProjectName; // update only changeable properties
                await this.dbContext.SaveChangesAsync();
            }

        }
        public async Task Delete(int ProjectId)
        {
            var project = await GetById(ProjectId);
            if (project != null)
            {
                dbContext.Projects.Remove(project);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
