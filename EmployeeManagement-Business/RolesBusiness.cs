//using EmployeeManagement.Data.Models;
//using EmployeeManagement_Repository;
//using EmployeeManagement_Repository.Entities;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace EmployeeManagement_Business
//{
//    public class RolesBusiness
//    {
//        private readonly RolesRepository rolesRepository;

//        public RolesBusiness()
//        {
//            rolesRepository = new RolesRepository();
//        }

//        public async Task<List<RolesModel>> GetRolesAsync()
//        {
          
//             return await rolesRepository.GetRolesAsync();

//        }

//        public async Task<RolesModel> GetRolesByID(int Id)
//        {
//            return await rolesRepository.GetRolesByID(Id);
//        }

//        public async Task DeleteRolesByID(int Id)
//        {
//            await rolesRepository.DeleteRolesByID(Id);
//        }

//        public async Task<HttpStatusCode> CreateRoles(CreateRolesModel createRolesModel)
//        {
//            var newRole = new Role();
//            newRole.RollName = createRolesModel.RollName;
//             rolesRepository.CreateRoles(newRole);
//            return HttpStatusCode.OK;

//        }

//        public async Task<HttpStatusCode> UpdateRolesAsync(RolesModel rolesModel)
//        {
//            var updatedrole = new Role();
//            updatedrole.Id = rolesModel.Id;
//            updatedrole.RollName = rolesModel.RollName;
//            await rolesRepository.UpdateRoles(updatedrole);
//            return HttpStatusCode.OK;


//        }
//}
//    }
