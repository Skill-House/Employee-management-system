using EmployeeManagement_Business;
using EmployeeManagement_Repository.Entities;
using Empolyee_Mangement.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class RoleController : ApiBaseController
    {
        private readonly RolesBuisness roleBusiness;

        public RoleController(RolesBuisness rolesBuisness)
        {
            roleBusiness = rolesBuisness;
        }
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetById(int RoleId)
        {
            var role = await roleBusiness.GetRoleAsync(RoleId);
            return Ok(role);
        }
        [HttpPost("CreateRoles")]
        public async Task<HttpStatusCode> CreateRole(RoleViewModel role)
        {
            return await roleBusiness.CreateRoleAsync(role);
            
        }
        [HttpGet("GetAllRoles")]
        
        public async Task<List<Role>> GetAllRole()
        {
           return await roleBusiness.GetAllRoles();
            
        }
      
        [HttpPut("UpdateRole")]
         
        public async Task <HttpStatusCode> UpdateRole(RoleViewModel role)
        {
            return await roleBusiness.UpdateRoleAsync(role);
        }
        [HttpDelete("DeleteRole")]
        
        public async Task <HttpStatusCode> DeleteRoleId(int RoleId)
        {
            return await roleBusiness.DeleteRoleAsync(RoleId);
        }
    }
}