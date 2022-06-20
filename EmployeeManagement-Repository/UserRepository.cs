using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository
{
    public class UserRepository
    {

        private readonly EmployeeManagementContext dbContext;

        public UserRepository()
        {
            dbContext = new EmployeeManagementContext();
        }
        public async Task<string> ValidateUser(string userID, string password)

        {
            var existinUser = dbContext.Users.FirstOrDefault(e => e.UserId == userID && e.Password == password);

            if (existinUser == null)
            {
                return "Login Unsuccessful";
            }

            return "User logged in successfully";
        }
    }
}
