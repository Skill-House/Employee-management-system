using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository.Contracts
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<User> GetById(int Id);
        Task Delete(int Id);
        Task<List<User>> GetAllUserAsync();
        Task<User> Login(string userEmail, string password);
        Task Update(User user);
    }
}
