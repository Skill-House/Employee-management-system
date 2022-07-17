using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using Empolyee_Mangement.Data.Models;

namespace EmployeeManagement_Business
{
    public class CompanyBuisness
    {
        private readonly CompanyRepository companyRepository;

        private readonly EmployeeRepository employeeRepository;

        public CompanyBuisness(CompanyRepository companyRepository, EmployeeRepository employeeRepository)
        {
            this.companyRepository = companyRepository;
            this.employeeRepository = employeeRepository;
        }

        public async Task<HttpStatusCode> CreateCompany(CompanyAddModel company)
    {
            var comp = new Company();
            comp.CompanyName = company.CompanyName;
            comp.CompanyAddress = company.CompanyAddress;
            comp.CompanyPhone = company.CompanyPhone;
            await companyRepository.Create(comp);
            return HttpStatusCode.OK;   
    }
        public async Task<HttpStatusCode> DeleteCompanyAsync(int Id)
        {
            var empPresent = 0;
            var existingemployee = this.employeeRepository.GetAllEmployeesAsync();

            foreach (var item in existingemployee.Result)
            {
                if (item.CompanyId == Id)
                {
                    empPresent = 1;
                    break;
                }
            }
            if (empPresent == 1)
            {
                return HttpStatusCode.InternalServerError;
            }
            else
            {
                await companyRepository.Delete(Id);
                return HttpStatusCode.OK;
            }
        }
        public async Task<Company> GetCompanyAsync(int Id)
        {
            var alumnus = await companyRepository.GetById(Id);
            return alumnus;
        }
        public async Task<List<Company>> GetAllCompanyAsync()
        {
            return await companyRepository.GetAllCompanyAsync();
        }
        public async Task<HttpStatusCode> UpdateCompanyAsync(CompanyUpdateModel company)
        {
            var comp = new Company();
            comp.CompanyId= company.CompanyId;
            comp.CompanyName = company.CompanyName;
            comp.CompanyAddress = company.CompanyAddress;
            comp.CompanyPhone = company.CompanyPhone;

            await companyRepository.Update(comp);
            return HttpStatusCode.OK;

        }
    }

}
