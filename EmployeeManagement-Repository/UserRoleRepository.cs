using EmployeeManagement_Repository.Contracts;
using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository
{
    public class UserRoleRepository: IUserRoleRepository
    {
        private readonly EmployeeManagementContext dbContext;
        public UserRoleRepository(EmployeeManagementContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Create(UserRole userole)
        {
            dbContext.UserRoles.Add(userole);
            await dbContext.SaveChangesAsync();
        }
    }
}
