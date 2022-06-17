using EmployeeManagement.Data.Models;
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

        [HttpGet("GetAllCompany")]
        public async Task<List<CompanyModel>>GetAllCompany()
        {
            return await companyBusiness.GetAllCompaniesAsync();
        }

        [HttpGet("GetByID")]
        public async Task<GetCompanyByIdModel> GetByID(int id)
        {
            return await companyBusiness.GetByID(id);
        }

        [HttpDelete("DeleteByID")]
        public async Task<IActionResult> DeleteByID(int id)
        {
            var result = await companyBusiness.DeleteByID(id);
            return Ok(result);
        }

        [HttpPost(Name = "SaveCompany")]
        public async Task<HttpStatusCode> SaveCompany(CompanyModel company)
        {
            return await companyBusiness.SaveCompanyAsync(company);
        }

        [HttpPut(Name = "UpdateCompany")]
        public async Task<HttpStatusCode> UpdateCompany(UpdateCompanyModel company)
        {
            return await companyBusiness.UpdateCompanyAsync(company);
        }



    }
}

