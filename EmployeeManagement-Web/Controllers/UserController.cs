using Microsoft.AspNetCore.Mvc;
using EmployeeManagement_Business;
using EmployeeManagement_Repository.Entities;

using System.Net;
using Empolyee_Mangement.Data;
using Empolyee_Mangement.Data.Models;
using System.Web;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ApiBaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserBusiness userBusiness;


        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            userBusiness = new UserBusiness();
        }

        [HttpGet("GetAllUser")]
        public async Task<List<User>> GetAllUser()
        {
            return await userBusiness.GetAllUserAsync();
        }
        [HttpGet(Name = "GetUser")]
        public async Task<IActionResult> GetById(int Id)
        {            var usrs = await userBusiness.GetUserAsync(Id);
            return Ok(usrs);
        }
        [HttpPost(Name = "SaveUser")]
        public async Task<HttpStatusCode> SaveUser(UserAddModel user)
        {
            return await userBusiness.SaveUserAsync(user);
        }
        [HttpPut(Name = "UpdateUser")]
        public async Task<HttpStatusCode> UpdateUser(User user)
        {
            return await userBusiness.UpdateUserAsync(user);
        }
        [HttpDelete(Name = "DeleteUser")]
        public async Task<IActionResult> DeleteById(int Id)
        {
            var usrs = await userBusiness.DeleteUserAsync(Id);
            return Ok(usrs);
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginmodel)
        {

            var login = await userBusiness.Login(loginmodel);
            if(login != null)
            {
                await userBusiness.PopulateJwtTokenAsync(login);
                var data = JsonConvert.SerializeObject(login);
                Response.Cookies.Append("ss", data);
                return Ok(login);
            }
            else
            {
                return BadRequest();
            }
    
                
        }
    }
}
