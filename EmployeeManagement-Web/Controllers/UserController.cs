using EmployeeManagement.Data.Models;
using EmployeeManagement_Business;
using EmployeeManagement_Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: Controller
    {

            private readonly UserBusiness userBusiness;

            public UserController()
            {
                userBusiness = new UserBusiness();
            }


         [HttpPost("ValidateUser")]
        public async Task<IActionResult> ValidateUser(UserModel userModel)
        {
            var existingUser = await userBusiness.ValidateUser(userModel);

            if (existingUser == null)
            {
                return NotFound();
            }

            return Ok();

        }
    }
}
