using EmployeeManagement_Repository.Contracts;
using EmployeeManagement_Repository.Entities;
using Empolyee_Mangement.Data;
using Empolyee_Mangement.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement_Business
{
    public class UserBusiness
    {
        private readonly IUserRepository userRepository;
        private readonly IUserRoleRepository userRoleRepository;
        public UserBusiness(IUserRepository _userRepository, IUserRoleRepository userRoleRepository)
        {
            this.userRepository = _userRepository;
            this.userRoleRepository = userRoleRepository;
        }


         public async Task<User> GetUserAsync(int Id)
        {
            var usrs = await userRepository.GetById(Id);
            return usrs;
        }
        public async Task<HttpStatusCode> SaveUserAsync(UserAddModel user)
        {
            var us = new User();
            us.FirstName = user.FirstName;
            us.UserEmail = user.UserEmail;
            us.Password = user.Password;
            await userRepository.Create(us);

            var userRole = new UserRole();
            userRole.UserId = us.Id;
            userRole.RoleId = user.RoleId;
             await userRoleRepository.Create(userRole);

            return HttpStatusCode.OK;

        }
        public async Task<HttpStatusCode> UpdateUserAsync(User user)
        {
            await userRepository.Update(user);
            return HttpStatusCode.OK;

        }
        public async Task<HttpStatusCode> DeleteUserAsync(int Id)
        {
             await userRepository.Delete(Id);
            return HttpStatusCode.OK;
        }
        public async Task<List<User>> GetAllUserAsync()
        {
            return await userRepository.GetAllUserAsync();
        }
        public async Task<AuthenticationModel> Login(LoginModel loginmodel)
        {
            var login = await userRepository.Login(loginmodel.UserEmail, loginmodel.Password);
            
            var authmodel = new AuthenticationModel();
            if (login != null)
            {
                authmodel.Name = login.FirstName;
                authmodel.UserId = login.Id;
                authmodel.Email = login.UserEmail;
                return authmodel;
            }
           
            return null;
        }
        public async Task PopulateJwtTokenAsync(AuthenticationModel authModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("!@#$%^&*()!@#$%^&*()");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.NameIdentifier, authModel.UserId.ToString()),
                        new Claim(ClaimTypes.Email, authModel.Email.ToString()),
                        new Claim(ClaimTypes.Name, authModel.Name.ToString())
                }),
                Expires = authModel.TokenExpiryDate = DateTime.UtcNow.AddMinutes(50),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            authModel.Token = tokenHandler.WriteToken(token);
        }
    }
}
