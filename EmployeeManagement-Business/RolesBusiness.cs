using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using Empolyee_Mangement.Data.Models;
using System.Net;

namespace EmployeeManagement_Business
{
    public class RolesBuisness
    {
        private readonly RolesRepository rolesRepository;
        
        public RolesBuisness(RolesRepository rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }
        public async Task<Role> GetRoleAsync(int roleId)
        {
            var role = await rolesRepository.GetById(roleId);
            return role;
        }
        public async Task<HttpStatusCode> CreateRoleAsync(RoleViewModel role)
        {
            var rol = new Role();
            rol.RoleId = role.RoleId;
            rol.RoleName = role.RoleName;
            await rolesRepository.Create(rol);
            return HttpStatusCode.OK;

        }
        public async Task<HttpStatusCode> UpdateRoleAsync(RoleViewModel role)
        {
            var rol= new Role();
            rol.RoleName=role.RoleName;
            rol.RoleId = role.RoleId;
            await rolesRepository.Update(rol);
            return HttpStatusCode.OK;
        }
        public async Task<HttpStatusCode> DeleteRoleAsync(int roleId)
        {
            var role = await rolesRepository.GetById(roleId);
            if (role == null)
            {
                return HttpStatusCode.NotFound;
            }
            else
            {
                await rolesRepository.Delete(roleId);
                return HttpStatusCode.OK;
            }
        }
            public async Task<List<Role>> GetAllRoles()
            {
            return await rolesRepository.GetAllRolesAsync();

            }
        
    }
}
