using EmployeeManagement_Business;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement_Repository.Entities;
using System.Net;
using EmployeeMangement.Data.Models;

namespace EmployeeManagement_Web.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class UserController : Controller
        {
            private readonly UserBuisness userBuisness;

            public UserController()
            {
                userBuisness = new UserBuisness();
            }

            [HttpGet("GetAllUser")]
            public async Task<List<UserModel>> GetAllCompany()
            {
                return await userBuisness.GetAllUserAsync();
            }
            [HttpGet("GetByID")]
            public async Task<User> GetByID(int id)
            {
                return await userBuisness.GetById(id);
            }
            [HttpPost("SaveUser")]
            public async Task<HttpStatusCode> SaveUserAsync(User user)
            {
                return await userBuisness.SaveUserAsync(user);
            }
            [HttpPut("UpdateUser")]
            public async Task<HttpStatusCode> UpdateUserAsync(User user)
            {
                return await userBuisness.UpdateUserAsync(user);
            }

            [HttpDelete("DeleteByID")]
            public async Task DeleteByID(int id)
            {
                var result = userBuisness.DeleteByID(id);
                Ok(result);
            }
        }
}
