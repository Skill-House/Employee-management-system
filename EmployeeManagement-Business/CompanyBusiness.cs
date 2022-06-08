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
        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await companyRepository.GetAllCompaniesAsync();
        }

        public async Task<Company> GetByID(int id)
        {
            return await companyRepository.GetByID(id);
        }
        public async Task<HttpStatusCode> SaveCompanyAsync(Company company)
        {
            await companyRepository.Create(company);
            return HttpStatusCode.OK;
        }

        public async Task<HttpStatusCode> DeleteByID(int id)
        {
            var result = companyRepository.DeleteByID(id);
            return HttpStatusCode.OK;

        }
    }
}

