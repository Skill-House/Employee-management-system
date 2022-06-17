using EmployeeManagement_Business;
using EmployeeManagement_Repository.Entities;
using EmployeeMangement.Data.Models;
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

        [HttpGet("GetAllCompany")]
        public async Task<List<CompanyModel>> GetAllCompany()
        {
            return await companyBusiness.GetAllCompaniesAsync();
        }
        [HttpGet("GetByID")]
        public async Task<Company> GetByID(int id)
        {
            return await companyBusiness.GetByID(id);
        }
        [HttpPost("SaveCompany")]
        public async Task<HttpStatusCode> SaveCompany(CompanyModel company)
        {
            return await companyBusiness.SaveCompanyAsync(company);
        }
        [HttpPut("UpdateCompany")]
        public async Task<HttpStatusCode> UpdateCompany(CompanyModel company)
        {
            return await companyBusiness.UpdateCompanyAsync(company);
        }
        
        [HttpDelete("DeleteByID")]
        public async Task DeleteByID(int id)
        {
            var result = companyBusiness.DeleteByID(id);
            Ok(result);
        }



    }
}

