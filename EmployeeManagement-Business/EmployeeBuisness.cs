using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using Empolyee_Mangement.Data.Models;
using System.Net;

namespace EmployeeManagement_Business
{
    public class EmployeeBuisness
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeeBuisness()
        {
            this.employeeRepository = new EmployeeRepository();
        }

        public async Task<Employee> GetEmployeeAsync(int Id)
        {
            var alumnus = await employeeRepository.GetById(Id);
            return alumnus;
        }
        public async Task<HttpStatusCode> SaveEmployeeAsync(EmployeeAddModel employee)
        {
            var emp = new Employee();
            emp.FirstName=employee.FirstName;
            emp.LastName=employee.LastName;
            emp.Email=employee.Email;
                emp.Phone=employee.Phone;
            emp.CompanyId=employee.CompanyId;
            emp.Gender=employee.Gender;
            emp.DateCreated = employee.DateCreated;
            emp.DateModified = employee.DateModified;
             await employeeRepository.Create(emp);
            return HttpStatusCode.OK;

        }
        public async Task<HttpStatusCode> UpdateEmployeeAsync(Employee employee)
        {
            await employeeRepository.Update(employee);
            return HttpStatusCode.OK;

        }
        public async Task<HttpStatusCode> DeleteEmployeeAsync(int Id)
        {
             await employeeRepository.Delete(Id);
            return HttpStatusCode.OK;
        }
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await employeeRepository.GetAllEmployeesAsync();
        }
    }
}