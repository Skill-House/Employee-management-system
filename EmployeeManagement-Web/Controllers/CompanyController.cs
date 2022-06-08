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
        public async Task<List<Company>>GetAllCompany()
        {
            return await companyBusiness.GetAllCompaniesAsync();
        }

        [HttpGet("GetByID")]
        public async Task<Company> GetByID(int id)
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
        public async Task<HttpStatusCode> SaveCompany(Company company)
        {
            return await companyBusiness.SaveCompanyAsync(company);
        }



    }
}

