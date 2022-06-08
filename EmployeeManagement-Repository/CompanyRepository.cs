using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository
{
    public class CompanyRepository
    {

        private readonly EmployeeManagementContext dbContext;
        public CompanyRepository()
        {
            this.dbContext = new EmployeeManagementContext();
        }
        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return  dbContext.Companies.ToList();
        }

        public async Task<Company> GetByID(int id)
        {
            return dbContext.Companies.FirstOrDefault(a=>a.CompanyId == id);
        }

        public  async Task Create(Company company)
        {
            dbContext.Companies.Add(company);
            await dbContext.SaveChangesAsync();
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
