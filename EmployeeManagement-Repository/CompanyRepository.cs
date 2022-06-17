using EmployeeManagement_Repository.Entities;
using EmployeeMangement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement_Repository
{
    public class CompanyRepository
    {

        private readonly EmployeeManagementContext dbContext;
        public CompanyRepository()
        {
            this.dbContext = new EmployeeManagementContext();
        }
        public async Task<List<CompanyModel>> GetAllCompaniesAsync()
        {
           
            var result = dbContext.Companies.Include(x => x.Employee).ToList();
            var companyDetails = new List<CompanyModel>();
            foreach (var company in result)
            {
                companyDetails.Add(new CompanyModel()
                {
                    EmployeeId = company.EmployeeId,
                    CompanyName = company.CompanyName,
                    CompanyAddress = company.CompanyAddress,
                    CompanyPhone = company.CompanyPhone,
                });
            }
            return companyDetails;
        }

        public async Task<Company> GetByID(int id)
        {
            return dbContext.Companies.FirstOrDefault(a=>a.CompanyId == id);
        }
        public async Task Create(Company company)
        {
            dbContext.Companies.Add(company);
            await dbContext.SaveChangesAsync();
        }
        public async Task Update(CompanyModel company)
        {
            var existingCompany = dbContext.Companies.FirstOrDefault(a => a.CompanyId == company.CompanyId);
            if (existingCompany != null)
            {
                existingCompany.CompanyId = company.CompanyId;
                existingCompany.CompanyName = company.CompanyName;
                existingCompany.CompanyAddress = company.CompanyAddress;
                existingCompany.CompanyPhone = company.CompanyPhone;
                await this.dbContext.SaveChangesAsync();
            }
        }


        public async Task DeleteByID(int id)
        {
            var company = await GetByID(id);

            if (company != null)
            {
                dbContext.Companies.Remove(company);
                dbContext.SaveChanges();
            }
        }
    }
}
