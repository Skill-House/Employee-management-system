using EmployeeManagement.Data.Models;
using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using EmployeeMangement.Data.Models;
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
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await employeeRepository.GetAllEmployeesAsync();
        }
        public async Task<Employee> GetEmployeeAsync(int Id)
        {
            var alumnus = await employeeRepository.GetById(Id);
            return alumnus;

        }
        public async Task<HttpStatusCode> SaveEmployeeAsync(EmployeeModel employee)
        {
            Employee emp = new Employee();
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Gender = employee.Gender;
            emp.Email = employee.Email;
            emp.Phone = employee.Phone;
            emp.DateCreated = employee.DateCreated;
            emp.DateModified = employee.DateModified;
            await employeeRepository.Create(emp);
            return HttpStatusCode.OK;

        }

        public Task<HttpStatusCode> SaveEmployeeAsync(EmployeeModel employee)
        {
            throw new NotImplementedException();
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

    }
}