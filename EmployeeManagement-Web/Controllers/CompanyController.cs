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

        private readonly ILogger<CompanyController> _logger;
        private readonly CompanyBusiness companyBusiness;

        public CompanyController(ILogger<CompanyController> logger)
        {
            _logger = logger;
            companyBusiness = new CompanyBusiness();
        }

        [HttpGet("GetAllCompany")]
        public async Task<List<Company>> GetAllCompany()
        {
            return await companyBusiness.GetAllCompanyAsync();
        }

        [HttpGet(Name = "GetCompany")]
        public async Task<IActionResult> GetById(int CompanyId)
        {
            var alumnus = await companyBusiness.GetCompanyAsync(CompanyId);
            return Ok(alumnus);
        }
        [HttpPost(Name = "SaveCompany")]
        public async Task<HttpStatusCode> SaveCompany(Company company)
        {
            return await companyBusiness.SaveCompanyAsync(company);
        }
        [HttpPut(Name = "UpdateCompany")]
        public async Task<HttpStatusCode> UpdateCompany(Company company)
        {
            return await companyBusiness.UpdateCompanyAsync(company);
        }
        [HttpDelete(Name = "DeeleteCompany")]
        public async Task<IActionResult> DeleteById(int CompanyId)
        {
            var alumnus = await companyBusiness.DeleteCompanyAsync(CompanyId);
            return Ok(alumnus);
        }
    }
}

