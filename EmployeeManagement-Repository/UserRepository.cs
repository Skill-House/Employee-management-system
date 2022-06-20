using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository
{
    public class UserRepository
    {
        private readonly EmployeeManagementContext dbContext;
        public UserRepository()
        {
            this.dbContext = new EmployeeManagementContext();
        }

        public async Task Create(User user)
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
        }
        public async Task Update(User user)
        {
            var existinguser = dbContext.Users.Where(h => h.Id == user.Id).FirstOrDefault();
            if (existinguser != null)
            {
                existinguser.FirstName = user.FirstName; 
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<User> GetById(int Id)
        {
            var usr = dbContext.Users.FirstOrDefault(e => e.Id == Id);
            return usr;
        }

        public async Task Delete(int Id)
        {
            var usr = await GetById(Id);
            if (usr != null)
            {
                dbContext.Users.Remove(usr);
                await this.dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<User>> GetAllUserAsync()
        {
            return dbContext.Users.ToList();
        }
        public async Task<User> Login(string userEmail,string password)
        {
            var user = dbContext.Users.SingleOrDefault(x => x.UserEmail == userEmail && x.Password == password);
            if(user!=null)
            {
                return user;
            }
            else
            {
                return user;
            }
        }
    }
}
