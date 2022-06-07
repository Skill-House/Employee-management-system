using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using System.Net;

namespace EmployeeManagement_Business
{
    public class CompanyBusiness
        {
            private readonly CompanyRepositorycs companyRepositorycs;
        public CompanyBusiness()
            {
                this.companyRepositorycs = new CompanyRepositorycs();
            }

        public CompanyRepositorycs GetCompanyRepositorycs()
        {
            return companyRepositorycs;
        }

        public async Task<List<Company>> GetAllCompanyAsync()
            {
                return await companyRepositorycs.GetAllCompanyAsync();
            }
            public async Task<Company> GetCompanyAsync(int CompanyId)
            {
                var alumnus = await companyRepositorycs.GetById(CompanyId);
                return alumnus;

            }
            public async Task<HttpStatusCode> SaveCompanyAsync(Company company)
            {
                await companyRepositorycs.Create(company);
                return HttpStatusCode.OK;

            }
            public async Task<HttpStatusCode> UpdateCompanyAsync(Company company)
            {
                await companyRepositorycs.Update(company);
                return HttpStatusCode.OK;

            }
            public async Task<HttpStatusCode> DeleteCompanyAsync(int Id)
            {
                await companyRepositorycs.Delete(Id);
                return HttpStatusCode.OK;
            }

        }
}

