using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement_Repository.Entities;

namespace EmployeeManagement_Repository
{
    public class CompanyRepository
    {

        private readonly EmployeeManagementContext dbContext;

        public CompanyRepository()
        {
            dbContext =new EmployeeManagementContext();
        }

        public async Task Create(Company company)
        {
            dbContext.Companies.Add(company);
            await dbContext.SaveChangesAsync();
        }
        public async Task<Company> GetById(int Id)
        {
            var company = dbContext.Companies.FirstOrDefault(e => e.CompanyId == Id);
            return company;
        }
        public async Task Delete(int companyId)
        {
            var company = await GetById(companyId);
            if (company != null)
            {
                dbContext.Companies.Remove(company);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Company>> GetAllCompanyAsync()
        {
            return dbContext.Companies.ToList();
        }
        public async Task Update(Company company)
        {
            var comp = dbContext.Companies.Where(h => h.CompanyId == company.CompanyId).FirstOrDefault();
            if (comp != null)
            {
                comp.CompanyName = company.CompanyName; 
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
