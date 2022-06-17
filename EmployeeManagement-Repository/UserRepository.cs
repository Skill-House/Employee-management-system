using EmployeeManagement_Repository.Entities;
using EmployeeMangement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace EmployeeManagement_Repository
{

    public class UserRepository
    {

        private readonly EmployeeManagementContext dbContext;

        public UserRepository()
        {
            this.dbContext = new EmployeeManagementContext();
        }

        public async Task<List<UserModel>> GetAllUserAsync()
        {
            var result = dbContext.Users.Include(x => x.Roll).ToList();
            var UserDetails = new List<UserModel>();
            
            foreach (var user in result)
            {
                UserDetails.Add(new UserModel()
                {
                    Id = user.Id,
                    UserId = user.UserId,
                    RollId = user.RollId,
                    Password = user.Password,
                });
            }
            return UserDetails;
        }
        // return dbContext.Users.ToList();

        public async Task<User> GetById(int UsersId)
        {
            var User = await dbContext.Users.FindAsync(UsersId);
            return User;


        }
        public async Task Create(User user)
        {
            await dbContext.Users.AddAsync(user);
            await this.dbContext.SaveChangesAsync();
        }



        public async Task Delete(int UsersId)
        {
            var User = await GetById(UsersId);
            if (User != null)
            {

                dbContext.Users.Remove(User);
                await this.dbContext.SaveChangesAsync();

            }
        }

        public async Task Update(User user)
        {
            var existingUser = dbContext.Users.Where(h => h.Id == user.Id).FirstOrDefault();
            if (existingUser != null)
            {
                existingUser.RollId = user.RollId; // update only changeable pro
                existingUser.UserId = user.UserId;
                existingUser.Password = user.Password;
                await this.dbContext.SaveChangesAsync();
            }
        }

    }   
}




