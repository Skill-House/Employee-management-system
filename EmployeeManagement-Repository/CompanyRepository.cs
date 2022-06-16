using EmployeeManagement.Data.Models;
using EmployeeManagement_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository.Entities
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

        public async Task DeleteByID(int id)
        {
            var company = await GetByID(id);

            if (company != null)
            {
                dbContext.Companies.Remove(company);
                dbContext.SaveChanges();
            }
        }
        public async Task Update(UpdateCompanyModel company)
        {
            var existingCompany = dbContext.Companies.Where(h => h.CompanyId == company.CompanyId).FirstOrDefault();
            if (existingCompany != null)
            {
                existingCompany.CompanyName = company.CompanyName; // update only changeable properties
                existingCompany.CompanyAddress = company.CompanyAddress;
                existingCompany.CompanyPhone = company.CompanyPhone;
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
