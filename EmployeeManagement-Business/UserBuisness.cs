using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using EmployeeMangement.Data.Models;
using System.Net;

namespace EmployeeManagement_Business
{
    public class UserBuisness
    {
        private readonly UserRepository userRepository;
        public UserBuisness()
        {
            this.userRepository = new UserRepository();
        }
        public async Task<List<UserModel>> GetAllUserAsync()
        {
            return await userRepository.GetAllUserAsync();
        }
        public async Task<User> GetById(int Id)
        {
            var user = await userRepository.GetById(Id);
            return user;

        }
        public async Task<HttpStatusCode> SaveUserAsync(User user)
        {
            await userRepository.Create(user);
            return HttpStatusCode.OK;

        }
        public async Task<HttpStatusCode> UpdateUserAsync(User user)
        {
            await userRepository.Update(user);
            return HttpStatusCode.OK;

        }
        public async Task<HttpStatusCode> DeleteByID(int Id)
        {
            await userRepository.Delete(Id);
            return HttpStatusCode.OK;
        }

    }
}

