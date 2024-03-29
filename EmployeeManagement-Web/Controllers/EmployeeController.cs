﻿using EmployeeManagement_Business;
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
        public async Task<List<Employee>> GetAllEmployee()
        {
             return await employeeBusiness.GetAllEmployeesAsync();
        }
        [HttpGet(Name = "GetEmployee")]
        public async Task<IActionResult> GetById(int employeeId)
        {
            var alumnus = await employeeBusiness.GetEmployeeAsync(employeeId);
            return Ok(alumnus);
        }
        [HttpPost(Name = "SaveEmployee")]
        public async Task<HttpStatusCode> SaveEmployee(EmployeeAddModel employee)
        {
            return await employeeBusiness.SaveEmployeeAsync(employee);
        }
        [HttpPut(Name = "UpdateEmployee")]
        public async Task<HttpStatusCode> UpdateEmployee(Employee employee)
        {
            return await employeeBusiness.UpdateEmployeeAsync(employee);
        }
        [HttpDelete(Name = "DeeleteEmployee")]
        public async Task<IActionResult> DeleteById(int employeeId)
        {
            var alumnus = await employeeBusiness.DeleteEmployeeAsync(employeeId);
            return Ok(alumnus);
        }
    }
}
