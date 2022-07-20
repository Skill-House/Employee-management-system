using EmployeeManagement_Business;
using EmployeeManagement_Repository.Entities;
using Empolyee_Mangement.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ApiBaseController
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly EmployeeBuisness employeeBusiness;


        public EmployeeController(ILogger<EmployeeController> logger, EmployeeBuisness employeeBuisness)
        {
            _logger = logger;
            employeeBusiness = employeeBuisness;
        }

        [HttpGet("GetAllEmployee")]
        public async Task<List<EmployeeViewModel>> GetAllEmployee()
        {
             return await employeeBusiness.GetAllEmployeesAsync();
        }
        [HttpGet("GetEmployee/{employeeId}")]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var alumnus = await employeeBusiness.GetEmployeeAsync(employeeId);
            return Ok(alumnus);
        }
        [HttpPost("SaveEmployee")]
        public async Task<HttpStatusCode> SaveEmployee(EmployeeAddModel employee)
        {
            return await employeeBusiness.SaveEmployeeAsync(employee);
        }
        [HttpPut("UpdateEmployee")]
        public async Task<HttpStatusCode> UpdateEmployee(EmployeeAddModel employee)
        {
            return await employeeBusiness.UpdateEmployeeAsync(employee);
        }
        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteById(int employeeId)
        {
            var alumnus = await employeeBusiness.DeleteEmployeeAsync(employeeId);
            return Ok(alumnus);
        }
    }
}
