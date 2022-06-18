using EmployeeManagement_Business;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement_Repository.Entities;
using EmployeeManagement.Data.Models;
using System.Net;

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : Controller
    {

        private readonly RolesBusiness rolesBusiness;

        public RolesController()
        {
            rolesBusiness = new RolesBusiness();
        }

        [HttpGet("GetAllRoles")]
        public async Task<List<RolesModel>> GetRoles()

        {
            var roles = await rolesBusiness.GetRolesAsync();
            return roles;
        }

       [HttpGet]
        public async Task<RolesModel> GetRolesByID(int id)
        {
        return await rolesBusiness.GetRolesByID(id);
        }

        [HttpDelete]
        public async Task DeleteRolesByID(int ID)
        {
            await rolesBusiness.DeleteRolesByID(ID);
        }
        [HttpPost]
        public async Task<HttpStatusCode> CreateRoles(CreateRolesModel createRolesModel)
        {
            await rolesBusiness.CreateRoles(createRolesModel);
            return HttpStatusCode.OK;

        }

        [HttpPut]
        public async Task<HttpStatusCode> UpdateRoles(RolesModel rolesModel)
        {
             await rolesBusiness.UpdateRolesAsync(rolesModel);
            return HttpStatusCode.OK;  
                }


    }
}
