using EmployeeManagement.Data.Models;
using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using EmployeeMangement.Data.Models;


//using Microsoft.AspNetCore.Mvc;
using System.Net;

#nullable disable


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
<<<<<<< HEAD
        public async Task<Company> GetByID(int id)
=======

        public async Task<GetCompanyByIdModel> GetByID(int id)
>>>>>>> origin/dev
        {
            return await companyRepository.GetByID(id);
        }
        public async Task<HttpStatusCode> SaveCompanyAsync(CompanyModel company)
        {
<<<<<<< HEAD
           // await companyRepository.Create(company);
=======
>>>>>>> origin/dev
            Company cmpn = new Company();
            cmpn.CompanyName = company.CompanyName;
            cmpn.CompanyAddress = company.CompanyAddress;
            cmpn.CompanyPhone = company.CompanyPhone;
            cmpn.EmployeeId = company.EmployeeId;
            await companyRepository.Create(cmpn);
            return HttpStatusCode.OK;
        }
<<<<<<< HEAD
        public async Task<HttpStatusCode> UpdateCompanyAsync(CompanyModel company)
        {
            await companyRepository.Update(company);
            return HttpStatusCode.OK;
        }
=======
>>>>>>> origin/dev

        public async Task<HttpStatusCode> DeleteByID(int id)
        {
            var result =  companyRepository.DeleteByID(id);
            return HttpStatusCode.OK;

        }
<<<<<<< HEAD
        //public async Task<HttpStatusCode> DeleteCompanyAsync(int Id)
        //{
        //    await companyRepository.Delete(Id);
        //    return HttpStatusCode.OK;
        //}
=======
        public async Task<HttpStatusCode> UpdateCompanyAsync(UpdateCompanyModel company)
        {
            await companyRepository.Update(company);
            return HttpStatusCode.OK;
>>>>>>> origin/dev

        }
    }
}


