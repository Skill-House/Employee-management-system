using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRepository
    {
        private readonly AlumniManagementContext dbContext;
        public UserRepository()
        {
            this.dbContext = new AlumniManagementContext();
        }

        public async Task Create(User user)
        {
            await dbContext.Users.AddAsync(user);
            await this.dbContext.SaveChangesAsync();
        }

        public User GetByCredentials(string userName, string password)
        {
            var user = dbContext.Users.Where(usr => usr.UserName == userName && usr.Password == password).FirstOrDefault();
            return user;
        }
    }
}
