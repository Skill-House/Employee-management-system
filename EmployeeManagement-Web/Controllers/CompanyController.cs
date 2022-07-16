using System.Net;
using EmployeeManagement_Business;
using EmployeeManagement_Repository.Entities;
using Empolyee_Mangement.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ApiBaseController
    {
        private readonly CompanyBuisness companyBusiness;

        public CompanyController(CompanyBuisness companyBuisness)
        {
            companyBusiness = companyBuisness;
        }

        [HttpPost("CreateCompany")]
        public async Task<HttpStatusCode> CreateCompany(CompanyAddModel company)
        {
            return await companyBusiness.CreateCompany(company);
        }
        [HttpGet("GetCompany")]
        public async Task<IActionResult> GetById(int companyId)
        {
            var company = await companyBusiness.GetCompanyAsync(companyId);
            return Ok(company);
        }

        [HttpDelete("{companyId}")]
        public async Task<IActionResult> DeleteByID(int companyId)
        {
            var delCompany = await companyBusiness.DeleteCompanyAsync(companyId);
            return Ok(delCompany);
        }
        [HttpGet("GetAllCompanies")]
        public async Task<List<Company>> GetAllCompanies()
        {
            return await companyBusiness.GetAllCompanyAsync();
        }

        [HttpPut("UpdateCompany")]
        public async Task<HttpStatusCode> UpdateCompany(CompanyUpdateModel company)
        {
            return await companyBusiness.UpdateCompanyAsync(company);
        }
    }
}
