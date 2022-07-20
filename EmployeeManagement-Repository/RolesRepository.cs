using EmployeeManagement_Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement_Repository
{
    public class RolesRepository
    {
        private readonly EmployeeManagementContext dbContext;
        public RolesRepository(EmployeeManagementContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Create(Role role)
        {
            dbContext.Roles.Add(role);
            await dbContext.SaveChangesAsync();

        }
        public async Task Update(Role role)
        {
            var existingRole = dbContext.Roles.Where(h => h.RoleId == role.RoleId).FirstOrDefault();
            if (existingRole != null)
            {
                existingRole.RoleName = role.RoleName;
                await this.dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<Role>> GetAllRolesAsync()
        {
            return dbContext.Roles.Include(x => x.UserRoles).ToList();
        }
        public async Task<Role> GetById(int roleId)
        {
            var role = dbContext.Roles.FirstOrDefault(r => r.RoleId == roleId);
            return role;
        }
        public async Task Delete(int rollId)
        {
            var roles = await GetById(rollId);
            if (roles!=null)
            {
                dbContext.Roles.Remove(roles);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
