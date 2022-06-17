using EmployeeManagement_Repository.Entities;

namespace EmployeeManagement_Repository
{
    public class CompanyRepository
    {
        private readonly EmployeeManagementContext dbContext;
        public CompanyRepository()
        {
            this.dbContext = new EmployeeManagementContext();
        }

        public async Task Update(Company company)
        {
            var existingCompany = dbContext.Companies.Where(h => h.CompanyId == company.CompanyId).FirstOrDefault();
            if (existingCompany != null)
            {
                existingCompany.CompanyName = company.CompanyName;
                existingCompany.CompanyAddress = company.CompanyAddress;
                existingCompany.CompanyPhone = company.CompanyPhone;
                await this.dbContext.SaveChangesAsync();
            }
        }

        public Task<List<Company>> GetAllCompanyAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Company> GetById(int CompanyId)
        {         
           var company = dbContext.Companies.FirstOrDefault(c => c.CompanyId== CompanyId);
            return company;
        }

    }
}