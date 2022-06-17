using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using System.Net;

namespace EmployeeManagement_Business
{
    public class CompanyBusiness
    {
        private readonly CompanyRepository companyRepository;
        public CompanyBusiness()
        {
            this.companyRepository = new CompanyRepository();
        }
        public async Task<List<Company>> GetAllCompanyAsync()
        {
            return await companyRepository.GetAllCompanyAsync();
        }

    
        public async Task<Company> GetCompanyAsync(int companyId)
        {
            var company = await companyRepository.GetById(companyId);
            return company;

        }

        public async Task<HttpStatusCode> UpdateCompanyAsync(Company company)
        {
            await companyRepository.Update(company);
            return HttpStatusCode.OK;

        }
   
    }
}


