using EmployeeManagement_Business;
using EmployeeManagement_Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CompanyController : Controller
    {
        
        private readonly CompanyBusiness companyBusiness;

        public CompanyController()
        {         
            companyBusiness = new CompanyBusiness();
        }


        [HttpGet(Name = "GetCompany")]
        public async Task<IActionResult> GetById(int companyId)
        {
            var company = await companyBusiness.GetCompanyAsync(companyId);
            return Ok(company);
        }

        [HttpPut(Name = "UpdateCompany")]
        public async Task<HttpStatusCode> UpdateCompany(Company company)
        {
            return await companyBusiness.UpdateCompanyAsync(company);
        }
    }
}

