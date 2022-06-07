using EmployeeManagement_Repository.Entities;

namespace EmployeeManagement_Repository
    {
        public class CompanyRepositorycs
    
        {
            private readonly EmployeeManagementContext dbContext;
            public CompanyRepositorycs()
            {
                this.dbContext = new EmployeeManagementContext();
            }
            public async Task<List<Company>> GetAllCompanyAsync()
            {
                return dbContext.Companies.ToList();
            }
            public async Task Create(Company company)
            {
                dbContext.Companies.Add(company);
                await dbContext.SaveChangesAsync();
            }

            public async Task Update(Company company)
            {
                var existingCompany = dbContext.Companies.Where(h => h.CompanyId == company.CompanyId).FirstOrDefault();
                if (existingCompany != null)
                {
                    existingCompany.CompanyName = company.CompanyName;
                existingCompany.CompanyAddress = company.CompanyAddress; // update only changeable properties
                    await this.dbContext.SaveChangesAsync();
                }
            }

            public async Task<Company> GetById(int CompanyId)
            {
                var company = dbContext.Companies.FirstOrDefault(e => e.CompanyId == CompanyId);
                return company;
            }

            public async Task Delete(int CompanyId)
            {
                var company = await GetById(CompanyId);
                if (company != null)
                {
                    dbContext.Companies.Remove(company);
                    await this.dbContext.SaveChangesAsync();
                }

            }
        }
    }