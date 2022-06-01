using EmployeeManagement_Web;

namespace EmployeeManagement_Repository
{
    public class EmployeeRepository
    {
        private readonly EmployeeManagementContext dbContext;
        public EmployeeRepository()
        {
            this.dbContext = new EmployeeManagementContext();
        }
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return dbContext.Employees.ToList();
        }
    }
}