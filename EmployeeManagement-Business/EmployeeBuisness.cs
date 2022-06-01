using EmployeeManagement_Repository;
using EmployeeManagement_Web;
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
    }
}