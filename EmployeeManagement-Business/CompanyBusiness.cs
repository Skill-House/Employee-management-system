using EmployeeManagement.Data.Models;
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
        public async Task<List<CompanyModel>> GetAllCompaniesAsync()
        {
            return await companyRepository.GetAllCompaniesAsync();
        }

        public async Task<GetCompanyByIdModel> GetByID(int id)
        {
            return await companyRepository.GetByID(id);
        }
        public async Task<HttpStatusCode> SaveCompanyAsync(CompanyModel company)
        {
            Company cmpn = new Company();
            cmpn.CompanyName = company.CompanyName;
            cmpn.CompanyAddress = company.CompanyAddress;
            cmpn.CompanyPhone = company.CompanyPhone;
            cmpn.EmployeeId = company.EmployeeId;
            await companyRepository.Create(cmpn);
            return HttpStatusCode.OK;
        }

        public async Task<HttpStatusCode> DeleteByID(int id)
        {
            var result = companyRepository.DeleteByID(id);
            return HttpStatusCode.OK;

        }
    }
}

