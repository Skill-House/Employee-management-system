using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository
{
    public class UserRoleRepository
    {
        private readonly EmployeeManagementContext dbContext;
        public UserRoleRepository()
        {
            this.dbContext = new EmployeeManagementContext();
        }
        public async Task Create(UserRole userole)
        {
            dbContext.UserRoles.Add(userole);
            await dbContext.SaveChangesAsync();
        }
    }
}
