using EmployeeManagement.Data.Models;
using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Business
{
    public class UserBusiness
    {


        private readonly UserRepository userRepository;

        public UserBusiness()
        {
            userRepository = new UserRepository();
        }
        public async Task<User> ValidateUser(UserModel userModel)

        {

            User existinUser = await userRepository.ValidateUser(userModel.UserId, userModel.Password);

            return existinUser;
        }
    }
}
